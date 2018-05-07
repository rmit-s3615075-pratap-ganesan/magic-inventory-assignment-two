using System;
namespace Magic_Inventory.ViewModel
{
    public class OwnerInventoryViewModel
    {
        public int ProductID { get; set; }
        public int StockLevel { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public OwnerInventoryViewModel(int ProductID,int StockLevel,string Name,decimal price){
            this.ProductID = ProductID;
            this.StockLevel = StockLevel;
            this.Name = Name;
            this.Price = price;
        }
    }
}
