namespace FinanceManagement.Transactions.Readers
{
    using System.Collections.ObjectModel;
    using System.IO;
    using Mappers;

    public abstract class TransactionReader<T>
    {
        private readonly TransactionMapper<T> _transactionMapper;

        protected TransactionReader(TransactionMapper<T> transactionMapper)
        {
            _transactionMapper = transactionMapper;
        }
        public Collection<T> GetTransactionsFromFile(string fileName)
        {
            using (var reader = File.OpenText(fileName))
            {
                return _transactionMapper.MapAll(reader);
            }
        }
    }
}
