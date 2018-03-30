namespace FinanceManagement.Transactions.Models
{
    using System;

    public class SantanderTransaction : ITransaction
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string MerchantOrDescription { get; set; }
        public decimal DebitOrCredit { get; set; }
        public decimal Balance { get; set; }
    }
}
