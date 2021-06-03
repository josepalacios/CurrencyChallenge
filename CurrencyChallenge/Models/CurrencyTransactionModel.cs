using System;

namespace CurrencyChallenge.Models
{
    public class CurrencyTransactionModel
    {
        public int CurrencyTransactionId { get; set; }
        public int UserId { get; set; }
        public int CurrencyId { get; set; }
        public decimal PurchasedAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
