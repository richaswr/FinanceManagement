namespace FinanceManagement.Transactions.Readers
{
    using DataAccess;
    using Mappers;
    using Models;

    public class SantanderTransactionReader : TransactionReader<SantanderTransaction>
    {
        public override Mapper<SantanderTransaction> Mapper => new SantanderTransactionMapper();
    }
}
