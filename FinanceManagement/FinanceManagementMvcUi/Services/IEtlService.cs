namespace FinanceManagementMvcUi.Services
{
    using System.Collections.ObjectModel;
    using FinanceManagement.ETL.Models;

    public interface IEtlService
    {
        /// <summary>
        /// Retrieve all ImportFileType records in the database.
        /// </summary>
        /// <returns></returns>
        Collection<ImportFileType> GetImportFileTypes();

        /// <summary>
        /// Get all active ImportFileType records from the database.
        /// </summary>
        /// <returns></returns>
        Collection<ImportFileType> GetActiveImportFileTypes();

        /// <summary>
        /// Get a specific ImportFileType record by it's Id value.
        /// </summary>
        /// <param name="importFileTypeId"></param>
        /// <returns></returns>
        ImportFileType GetImportFileTypeById(int importFileTypeId);

        /// <summary>
        /// Update an ImportFileType record.
        /// </summary>
        /// <param name="importFileType"></param>
        void UpdateImportFileType(ImportFileType importFileType);

        ImportFileType CreateImportFileType(ImportFileType importFileType);
    }
}
