namespace FinanceManagementMvcUi.Services
{
    using System.Collections.ObjectModel;
    using FinanceManagement.Transactions.Models;
    using FinanceManagement.Transactions.Repositories;

    public interface ITransactionService
    {
        TransactionSearchResult GetFinanceTransactions(TransactionSearchCriteria searchCriteria);
    }
}
