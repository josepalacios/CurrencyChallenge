using System.ComponentModel.DataAnnotations;

namespace CurrencyChallenge.Entities
{
    public class DolarExchangeRate
    {
        [Required]
        public string PurchasePrice { get; set; }

        [Required]
        public string SalePrice { get; set; }
    }
}
