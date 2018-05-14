namespace FinanceManagement.Transactions.Repositories
{
    using System.Collections.ObjectModel;
    using Models;

    public class TransactionSearchResult
    {
        public int TotalNumberOfRecords { get; set; }
        public Collection<FinanceTransaction> FinanceTransactions { get; set; }
    }
}
