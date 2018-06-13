namespace FinanceManagement.ETL.Repositories
{
    using System;
    using System.Collections.ObjectModel;
    using Models;

    public interface IEtlRepository
    {
        /// <summary>
        /// Creates an ImportFileBatch record for the file and configuration specified.
        /// </summary>
        /// <param name="importFileType"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        ImportFileBatch CreateImportFileBatch(ImportFileType importFileType, string fileName);

        /// <summary>
        /// Creates a new ImportFileType record.
        /// </summary>
        /// <param name="importFileType"></param>
        /// <returns></returns>
        ImportFileType CreateImportFileType(ImportFileType importFileType);

        /// <summary>
        /// Retrieves all ImportFileBatches
        /// </summary>
        /// <returns></returns>
        Collection<ImportFileBatch> GetImportFileBatches();

        /// <summary>
        /// Retrieves all ImportFileBatches by type created after the specified date
        /// </summary>
        /// <param name="fromDate"></param>
        /// <returns></returns>
        Collection<ImportFileBatch> GetImportFileBatchesByTypeAndDate(ImportFileType importFileType, DateTime fromDate);

        /// <summary>
        /// Returns all errors for a batch
        /// </summary>
        /// <param name="importFileBatch"></param>
        /// <returns></returns>
        Collection<ImportFileBatchError> GetImportFileBatchErrors(ImportFileBatch importFileBatch);

        /// <summary>
        /// Retrieves all import files types.
        /// </summary>
        /// <returns></returns>
        Collection<ImportFileType> GetImportFileTypes();

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

        /// <summary>
        /// Update an ImportFileType record.
        /// </summary>
        /// <param name="importFileType"></param>
        void UpdateImportFileType(ImportFileType importFileType);
    }
}
