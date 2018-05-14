namespace FinanceManagementMvcUi.Services
{
    using FinanceManagement.Transactions.Repositories;

    public class TransactionService : ITransactionService
    {
        private readonly TransactionRepository _transactionRepository;

        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
        }

        public TransactionSearchResult GetFinanceTransactions(TransactionSearchCriteria searchCriteria)
        {
            return _transactionRepository.GetFinanceTransactions(searchCriteria);
        }
    }
}
