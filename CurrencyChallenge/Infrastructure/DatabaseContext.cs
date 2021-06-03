using CurrencyChallenge.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyChallenge.Infrastructure
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyTransaction> CurrencyTransactions { get; set; }
    }
}
