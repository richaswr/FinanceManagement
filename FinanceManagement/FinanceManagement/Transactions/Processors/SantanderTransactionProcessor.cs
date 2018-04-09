namespace FinanceManagement.Transactions.Processors
{
    using System.IO;
    using ETL;
    using ETL.Models;
    using ETL.Repositories;
    using Mappers;
    using Models;
    using Readers;
    using Writers;

    public class SantanderTransactionProcessor : ITransactionProcessor
    {
        private readonly ImportFileType _importFileType;
        private readonly IEtlRepository _etlRepository;
        private readonly TransactionReader<SantanderTransaction> _transactionReader;

        public SantanderTransactionProcessor(ImportFileType importFileType, IEtlRepository etlRepository)
        {
            _importFileType = importFileType;
            _etlRepository = etlRepository;
            _transactionReader = new SantanderTransactionReader(new SantanderTransactionMapper(importFileType.ColumnDelimiter));
        }

        public void Execute()
        {
            foreach (var sourceFile in Directory.GetFiles(_importFileType.SourceDirectory, _importFileType.FileNamePattern))
            {
                var importFileBatch = _etlRepository.CreateImportFileBatch(_importFileType, sourceFile);
                var transactions = _transactionReader.GetTransactionsFromFile(sourceFile);

                var bulkWriter = new SantanderTransactionBulkWriter(importFileBatch);
                bulkWriter.Execute(transactions);

                _etlRepository.UpdateImportFileBatchRecordCount(importFileBatch, transactions.Count);
                _etlRepository.UpdateImportFileBatchStatus(importFileBatch, ImportFileBatchStatus.Staged);
                _etlRepository.ExecutePostLoadProcedure(importFileBatch);
            }
        }
    }
}
