using Microsoft.EntityFrameworkCore;

namespace WiredBrainCoffeeAdmin.Data
{
    public class WiredContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        public WiredContext(DbContextOptions options):base(options) { }
    }
}
