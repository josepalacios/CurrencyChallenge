using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyChallenge.Entities
{
    public class CurrencyTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrencyTransactionId { get; set; }

        [Required, ForeignKey("UserId")]
        public int UserId { get; set; }

        [Required, ForeignKey("CurrencyId")]
        public int CurrencyId { get; set; }

        [Required, Column(TypeName = "decimal(18,2)")]
        public decimal PurchasedAmount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }
    }
}
