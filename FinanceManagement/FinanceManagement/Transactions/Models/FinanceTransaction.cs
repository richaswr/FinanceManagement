namespace FinanceManagement.Transactions.Models
{
    using System;

    public class FinanceTransaction
    {
        public int FinanceTransactionId { get; set; }
        public DateTime DateCreated { get; set; }
        public short TransactionTypeId { get; set; }
        public decimal? TransferAmount { get; set; }
        public DateTimeOffset? TransactionDate { get; set; }
        public string ExternalTransactionId { get; set; }
    }
}