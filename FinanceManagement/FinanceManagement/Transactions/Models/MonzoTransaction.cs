namespace FinanceManagement.Transactions.Models
{
    using System;

    public class MonzoTransaction : ITransaction
    {
        public string Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public decimal LocalAmount { get; set; }
        public string LocalCurrency { get; set; }
        public string Category { get; set; }
        public string Emoji { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public string Receipt { get; set; }
    }
}
