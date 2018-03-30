namespace FinanceManagement.Transactions.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class SantanderTransactionMapper : Mapper<SantanderTransaction>
    {
        protected override SantanderTransaction Map(IDataRecord record)
        {
            return new SantanderTransaction
            {
                Date = DateTime.Parse(record["Date"].ToString()),
                Type = record["Type"].ToString(),
                MerchantOrDescription = record["Merchant/Description"].ToString(),
                DebitOrCredit = decimal.Parse(record["Debit/Credit"].ToString()),
                Balance = decimal.Parse(record["Balance"].ToString())
            };
        }
    }
}
