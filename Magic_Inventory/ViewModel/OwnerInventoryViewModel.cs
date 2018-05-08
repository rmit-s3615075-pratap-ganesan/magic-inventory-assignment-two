using System;
using Magic_Inventory.Models;
using Magic_Inventory.Utility;

namespace Magic_Inventory.ViewModel
{
    public class OwnerInventoryViewModel
    {
        public PaginatedList<OwnerInventory> Inventory { get; set; }
    }
}
