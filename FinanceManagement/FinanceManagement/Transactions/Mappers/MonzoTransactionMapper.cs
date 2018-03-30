namespace FinanceManagement.Transactions.Mappers
{
    using System;
    using System.Data;
    using System.Globalization;
    using DataAccess;
    using Models;

    public class MonzoTransactionMapper : Mapper<MonzoTransaction>
    {
        protected override MonzoTransaction Map(IDataRecord record)
        {
            return new MonzoTransaction
            {
                Id = record["id"] == DBNull.Value ? string.Empty : record["id"].ToString(),
                Created = GetCreatedDateTime(record["created"].ToString()),
                Amount = decimal.Parse(record["amount"].ToString()),
                Currency = record["currency"] == DBNull.Value ? string.Empty : record["currency"].ToString(),
                LocalAmount = decimal.Parse(record["local_amount"].ToString()),
                LocalCurrency = record["local_currency"] == DBNull.Value ? string.Empty : record["local_currency"].ToString(),
                Category = record["category"] == DBNull.Value ? string.Empty : record["category"].ToString(),
                Emoji = record["emoji"] == DBNull.Value ? string.Empty : record["emoji"].ToString(),
                Description = record["description"] == DBNull.Value ? string.Empty : record["description"].ToString(),
                Address = record["address"] == DBNull.Value ? string.Empty : record["address"].ToString(),
                Receipt = record["receipt"] == DBNull.Value ? string.Empty : record["receipt"].ToString()
            };
        }

        #region Methods

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
