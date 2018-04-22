using Microsoft.EntityFrameworkCore;
using Magic_Inventory.Models;

namespace Magic_Inventory.Data
{
    public class InventoryContext : DbContext
    {

        public DbSet<OwnerInventory> OwnerInventory { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        { }

    }
}
