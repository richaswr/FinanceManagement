namespace FinanceManagement.Transactions.Readers
{
    using Mappers;
    using Models;

    public class MonzoTransactionReader : TransactionReader<MonzoTransaction>
    {
        public MonzoTransactionReader(TransactionMapper<MonzoTransaction> transactionMapper) : base(transactionMapper)
        {
        }
    }
}
