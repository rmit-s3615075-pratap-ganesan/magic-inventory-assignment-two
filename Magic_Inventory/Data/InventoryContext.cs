using Microsoft.EntityFrameworkCore;
using Magic_Inventory.Models;

namespace Magic_Inventory.Data
{
    public class InventoryContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<OwnerInventory> OwnerInventory { get; set; }
        public DbSet<StockRequest> StockRequest { get; set; }


        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StoreInventory>().HasKey(x => new { x.StoreID, x.ProductID });
        }

    }
}
