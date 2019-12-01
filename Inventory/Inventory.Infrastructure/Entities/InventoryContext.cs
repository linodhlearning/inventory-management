using Microsoft.EntityFrameworkCore;
namespace Inventory.Infrastructure.Entities
{
    public class InventoryContext : DbContext
    {
        //private string ConnectionString { get; set; }
        //public InventoryContext(string connectionString) { this.ConnectionString = connectionString; }

        public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(this.ConnectionString);
            // optionsBuilder.UseSqlServer( @"Server=(localdb)\mssqllocaldb;Database=InventoryDB;Integrated Security=True");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

}
