namespace FinanceManagement.Transactions.Processors
{
    using ETL.Models;

    public interface ITransactionProcessor
    {
        void Execute();
    }
}
