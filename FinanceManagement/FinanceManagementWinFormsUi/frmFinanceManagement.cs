namespace FinanceManagementWinFormsUi
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Forms;
    using FinanceManagement.ETL.Models;
    using FinanceManagement.ETL.Repositories;
    using FinanceManagement.Transactions;

    public partial class frmFinanceManagement : Form
    {
        private readonly EtlRepository _etlRepository;
        public frmFinanceManagement()
        {
            InitializeComponent();
            _etlRepository = new EtlRepository();
        }

        private void btnGetConfigs_Click(object sender, EventArgs e)
        {
            var configsAsDataTable = TypeTranslator<ImportFileType>.GetDataTableFromSource(_etlRepository.GetImportFileTypes().Where(w => w.IsActive).ToList());
            configsAsDataTable.Columns.Add("Selected", typeof(bool));
            dgvConfigs.AutoGenerateColumns = true;
            dgvConfigs.DataSource = configsAsDataTable;            
            dgvConfigs.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            TypeTranslator<ImportFileType>.HideGridViewColumns(dgvConfigs);
        }

        private void btnGridSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvConfigs.Rows)
            {
                var selectedCheckBox = (DataGridViewCheckBoxCell)row.Cells["Selected"];
                selectedCheckBox.Value = true;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                var importFileTypes = TypeTranslator<ImportFileType>.GetSourceFromDataGridView(dgvConfigs);
                var importFileBatches = new Collection<ImportFileBatch>();

                foreach (var importFileType in importFileTypes)
                {
                    var timeStamp = DateTime.Now;
                    var processor = TransactionProcessorFactory.GetTransactionProcessor(importFileType, _etlRepository);
                    processor.Execute();

                    var batches = _etlRepository.GetImportFileBatchesByTypeAndDate(importFileType, timeStamp);

                    foreach (var batch in batches)
                    {
                        importFileBatches.Add(batch);
                    }
                }

                var batchesAsDataTable = TypeTranslator<ImportFileBatch>.GetDataTableFromSource(importFileBatches);
                dgvBatches.AutoGenerateColumns = true;
                dgvBatches.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvBatches.DataSource = batchesAsDataTable;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void frmFinanceManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnGetExisting_Click(object sender, EventArgs e)
        {
            var selectedTimestamp = dtpFromDate.Value;

            var importFileBatches = new Collection<ImportFileBatch>();

            foreach (var importFileType in _etlRepository.GetImportFileTypes())
            {
                foreach (var importFileBatch in _etlRepository.GetImportFileBatchesByTypeAndDate(importFileType, selectedTimestamp))
                {
                    importFileBatches.Add(importFileBatch);
                }
            }

            var batchesAsDataTable = TypeTranslator<ImportFileBatch>.GetDataTableFromSource(importFileBatches);
            dgvBatches.AutoGenerateColumns = true;
            dgvBatches.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvBatches.DataSource = batchesAsDataTable;
        }

        private void hideErrorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (scBatchErrors.Visible)
            {
                Height = Height - scBatchErrors.Height;
                hideErrorsToolStripMenuItem.Text = @"Show Errors";
            }
            else
            {
                Height = Height + scBatchErrors.Height;
                hideErrorsToolStripMenuItem.Text = @"Hide Errors";
            }

            scBatchErrors.Visible = !scBatchErrors.Visible;
        }

        private void btnShowErrors_Click(object sender, EventArgs e)
        {
            var importFileBatchErrors = new Collection<ImportFileBatchError>();
            foreach (DataGridViewRow batchRow in dgvBatches.SelectedRows)
            {
                var importFileBatch = TypeTranslator<ImportFileBatch>.GetItemFromDataGridViewRow(batchRow);
                foreach (var importFileBatchError in _etlRepository.GetImportFileBatchErrors(importFileBatch))
                {
                    importFileBatchErrors.Add(importFileBatchError);
                }
            }

            var errorsAsDataTable = TypeTranslator<ImportFileBatchError>.GetDataTableFromSource(importFileBatchErrors);
            dgvBatchErrors.AutoGenerateColumns = true;
            dgvBatches.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvBatchErrors.DataSource = errorsAsDataTable;
        }
    }
}
