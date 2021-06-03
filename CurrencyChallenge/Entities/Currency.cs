using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyChallenge.Entities
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
