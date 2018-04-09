namespace FinanceManagement.Transactions.Readers
{
    using Mappers;
    using Models;

    public class SantanderTransactionReader : TransactionReader<SantanderTransaction>
    {
        public SantanderTransactionReader(TransactionMapper<SantanderTransaction> transactionMapper) : base(transactionMapper)
        {
        }
    }
}
