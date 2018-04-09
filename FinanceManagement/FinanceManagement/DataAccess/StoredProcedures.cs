namespace FinanceManagement.DataAccess
{
    public class StoredProcedures
    {
        public const string CreateImportFileBatch = "etl.CreateImportFileBatch";
        public const string GetActiveImportFiles = "etl.GetActiveImportFileTypes";
        public const string UpdateImportFileBatchRecordCount = "etl.UpdateImportFileBatchRecordCount";
        public const string UpdateImportFileBatchStatus = "etl.UpdateImportFileBatchStatus";
    }
}
