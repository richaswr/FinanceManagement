namespace FinanceManagement.Transactions.Mappers
{
    using System;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using ETL;
    using Models;
    using Validation;

    public class MonzoTransactionMapper : TransactionMapper<MonzoTransaction>
    {
        private readonly string _columnDelimiter;

        public MonzoTransactionMapper(string columnDelimiter)
        {
            _columnDelimiter = columnDelimiter;
        }

        protected override MonzoTransaction Map(string row)
        {
            var cols = row.Split(new[] { _columnDelimiter }, StringSplitOptions.None);
            return new MonzoTransaction
            {
                Id = string.IsNullOrEmpty(cols[0]) ? string.Empty : cols[0],
                Created = GetCreatedDateTime(cols[1]),
                Amount = decimal.Parse(cols[2]),
                Currency = string.IsNullOrEmpty(cols[3]) ? string.Empty : cols[3],
                LocalAmount = decimal.Parse(cols[4]),
                LocalCurrency = string.IsNullOrEmpty(cols[5]) ? string.Empty : cols[5],
                Category = string.IsNullOrEmpty(cols[6]) ? string.Empty : cols[6],
                Emoji = string.IsNullOrEmpty(cols[7]) ? string.Empty : cols[7],
                Description = string.IsNullOrEmpty(cols[8]) ? string.Empty : cols[8],
                Address = string.IsNullOrEmpty(cols[9]) ? string.Empty : cols[9],
                Receipt = string.IsNullOrEmpty(cols[10]) ? string.Empty : cols[10]
            };
        }

        protected override Ruleset ValidationRuleset(string row, int rowIndex)
        {
            return new Ruleset(row, rowIndex).IgnoreHeaderRow();
        }

        #region Helpers

        public DateTimeOffset GetCreatedDateTime(string sourceDate)
        {
            var enGb = new CultureInfo("en-GB");
            var fullDateTimeStamp = GetCorrectedDateString(sourceDate);
            DateTimeOffset convertedDateTime;

            if (DateTimeOffset.TryParseExact(fullDateTimeStamp, "yyyy-MM-dd HH:mm:ss zzz", enGb, DateTimeStyles.None, out convertedDateTime))
            {
                return convertedDateTime;
            }

            var partDateTimeStamp = GetCorrectedDateString(sourceDate, true);
            return DateTimeOffset.ParseExact(partDateTimeStamp, "yyyy-MM-dd HH:mm:ss zzz", enGb, DateTimeStyles.None);
        }

        private static string GetCorrectedDateString(string source, bool getFlatTimeStamp = false)
        {
            var parts = source.Split(' ');
            var timePart = GetCorrectedTimeString(parts[1], getFlatTimeStamp);
            return string.Concat(parts[0], " ", timePart, " ", parts[2]);
        }

        private static string GetCorrectedTimeString(string timeString, bool getFlatTimeStamp)
        {
            if (getFlatTimeStamp)
            {
                return "00:00:00 +0000";
            }

            var timeParts = timeString.Split(':');

            var hours = timeParts[0];
            var minutes = timeParts[1];
            var seconds = int.Parse(timeParts[2]) > 59 ? "00" : timeParts[2];

            return string.Concat(hours, ":", minutes, ":", seconds);
        }

        #endregion
    }
}
