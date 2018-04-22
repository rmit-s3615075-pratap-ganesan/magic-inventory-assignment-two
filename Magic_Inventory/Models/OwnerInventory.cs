using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Magic_Inventory.Models
{
    public class OwnerInventory
    {
        [Key]     
        public int ProductID { get; set; }

        public int StockLevel { get; set; }
    }
}
