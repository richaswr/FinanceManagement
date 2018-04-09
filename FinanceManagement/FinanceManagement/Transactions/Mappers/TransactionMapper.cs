namespace FinanceManagement.Transactions.Mappers
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using ETL;

    public abstract class TransactionMapper<T>
    {
        public Collection<T> MapAll(StreamReader reader)
        {
            string row;
            var rowIndex = 0;
            var transactions = new Collection<T>();

            while ((row = reader.ReadLine()) != null)
            {
                rowIndex++;
                if (ValidationRuleset(row, rowIndex).Rules.Any(a => a.Invoke()))
                {
                    continue;
                }

                transactions.Add(Map(row));
            }

            return transactions;
        }

        protected abstract T Map(string row);
        protected abstract Ruleset ValidationRuleset(string row, int rowIndex);
    }
}