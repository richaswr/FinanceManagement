namespace FinanceManagement.ETL.Repositories
{
    using System.Collections.ObjectModel;
    using Models;

    public interface IEtlRepository
    {
        /// <summary>
        /// Creates an ImportFileBatch recor for the file and configuration specified.
        /// </summary>
        /// <param name="importFileType"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        ImportFileBatch CreateImportFileBatch(ImportFileType importFileType, string fileName);

        /// <summary>
        /// Retrieves all currently active import files.
        /// </summary>
        /// <returns></returns>
        Collection<ImportFileType> GetActiveImportFileTypes();

        /// <summary>
        /// BreaksValidation the post load procedures associated with the ImportFileType configuration.
        /// </summary>
        /// <param name="importFileBatch"></param>
        void ExecutePostLoadProcedure(ImportFileBatch importFileBatch);

        /// <summary>
        /// Update the batch record count of the provided batch.
        /// </summary>
        /// <param name="importFileBatch"></param>
        /// <param name="batchRecordCount"></param>
        void UpdateImportFileBatchRecordCount(ImportFileBatch importFileBatch, int batchRecordCount);

        /// <summary>
        /// Update the batch ImportFileBatchStatusId of the provided batch.
        /// </summary>
        /// <param name="importFileBatch"></param>
        /// <param name="importFileBatchStatus"></param>
        void UpdateImportFileBatchStatus(ImportFileBatch importFileBatch, ImportFileBatchStatus importFileBatchStatus);
    }
}
