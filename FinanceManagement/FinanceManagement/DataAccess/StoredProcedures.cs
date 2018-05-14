namespace FinanceManagement.DataAccess
{
    public class StoredProcedures
    {
        public const string CreateImportFileBatch = "etl.CreateImportFileBatch";
        public const string GetImportFileTypes = "etl.GetImportFileTypes";
        public const string UpdateImportFileBatchRecordCount = "etl.UpdateImportFileBatchRecordCount";
        public const string UpdateImportFileBatchStatus = "etl.UpdateImportFileBatchStatus";
        public const string GetImportFileBatchesByTypeAndDate = "etl.GetImportFileBatchesByTypeAndDate";
        public const string GetImportFileBatchErrors = "etl.GetImportFileBatchErrors";
        public const string UpdateImportFileType = "etl.UpdateImportFileType";
        public const string CreateImportFileType = "etl.CreateImportFileType";

        public const string GetFinanceTransactions = "dbo.GetFinanceTransactions";
    }
}
