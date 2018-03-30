namespace FinanceManagement.Transactions.Readers
{
    using System.Collections.ObjectModel;
    using System.IO;
    using DataAccess;
    using Transactions;

    public abstract class TransactionReader<T> : DataContext where T: ITransaction
    {
        public abstract Mapper<T> Mapper { get; }
        public Collection<T> GetTransactionsFromFile(string fileName)
        {
            var directory = Directory.GetParent(fileName);
            SetOdbcConnection(directory.ToString());
            using (var command = CreateOdbcCommand(fileName))
            {
                Connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    return Mapper.MapAll(reader);
                }
            }
        }
    }
}
