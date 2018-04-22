using System;
namespace Magic_Inventory.Data
{
    public class Context

    {
    
        public DbSet<OwnerInventory> OwnerInventory { get; set; }


        public Context()
        {
        }
    }
}
