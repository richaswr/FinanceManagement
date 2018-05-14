namespace FinanceManagement.Transactions.Mappers
{
    using System;
    using System.Data;
    using DataAccess;
    using Models;

    public class FinanceTransactionMapper : DataMapper<FinanceTransaction>
    {
        protected override FinanceTransaction Map(IDataRecord record)
        {            
            return new FinanceTransaction
            {
                DateCreated = DateTime.Parse(record["DateCreated"].ToString()),
                ExternalTransactionId = record["ExternalTransactionId"] == DBNull.Value ? string.Empty : record["ExternalTransactionId"].ToString(),
                FinanceTransactionId = int.Parse(record["FinanceTransactionId"].ToString()),
                TransactionDate = record["TransactionDate"] == DBNull.Value ? (DateTimeOffset?)null : DateTimeOffset.Parse(record["TransactionDate"].ToString()),
                TransactionTypeId = short.Parse(record["TransactionTypeId"].ToString()),
                TransferAmount = record["TransferAmount"] == DBNull.Value ? default(decimal) : decimal.Parse(record["TransferAmount"].ToString())
            };
        }
    }
}