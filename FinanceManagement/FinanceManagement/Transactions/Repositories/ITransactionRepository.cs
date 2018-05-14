namespace FinanceManagement.Transactions.Repositories
{
    public interface ITransactionRepository
    {
        TransactionSearchResult GetFinanceTransactions(TransactionSearchCriteria transactionSearchCriteria);
    }
}
