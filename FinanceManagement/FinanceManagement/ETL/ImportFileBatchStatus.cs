namespace FinanceManagement.ETL
{
    public enum ImportFileBatchStatus
    {
        Pending = 1,
        Staged = 2,
        Loaded = 3,
        Rejected = 4,
        Error = 5
    }
}
