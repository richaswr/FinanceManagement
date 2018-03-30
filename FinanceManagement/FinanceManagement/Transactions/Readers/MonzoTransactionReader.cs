namespace FinanceManagement.Transactions.Readers
{
    using DataAccess;
    using Mappers;
    using Models;

    public class MonzoTransactionReader : TransactionReader<MonzoTransaction>
    {
        public override Mapper<MonzoTransaction> Mapper => new MonzoTransactionMapper();
    }
}
