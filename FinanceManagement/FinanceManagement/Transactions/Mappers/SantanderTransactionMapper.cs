namespace FinanceManagement.Transactions.Mappers
{
    using System;
    using System.Text.RegularExpressions;
    using ETL;
    using Models;

    public class SantanderTransactionMapper : TransactionMapper<SantanderTransaction>
    {
        private readonly string _columnDelimiter;

        public SantanderTransactionMapper(string columnDelimiter)
        {
            _columnDelimiter = columnDelimiter;
        }

        protected override SantanderTransaction Map(string row)
        {
            var cols = row.Split(new[] {_columnDelimiter}, StringSplitOptions.None);
            return new SantanderTransaction
            {
                Date = DateTime.Parse(cols[0]),
                Type = cols[1],
                MerchantOrDescription = cols[2],
                DebitOrCredit = decimal.Parse(cols[3].RemoveNonNumeric()),
                Balance = decimal.Parse(cols[4].RemoveNonNumeric())
            };
        }

        protected override Ruleset ValidationRuleset(string row, int rowIndex)
        {
            return new Ruleset(row, rowIndex)
                .IgnoreHeaderRow()
                .StartsWith("Arranged")
                .HasEmptyColumn(_columnDelimiter, 0);
        }
    }
}