namespace FinanceManagement.Transactions.Repositories
{
    public class TransactionSearchCriteria
    {
        public bool SortByTransactionIdAscending { get; set; }
        public int PageSize { get; set; }
        public int PageRank { get; set; }
    }
}
