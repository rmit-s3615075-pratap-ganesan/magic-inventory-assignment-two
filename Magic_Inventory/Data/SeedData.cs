using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Magic_Inventory.Models;
namespace Magic_Inventory.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new InventoryContext(
                serviceProvider.GetRequiredService<DbContextOptions<InventoryContext>>()))
            {
                // Look for any products.
                if (context.Product.Any())
                {
                    return; // DB has been seeded.
                }

                var products = new[]
                {
                    new Product
                    {
                        Name = "Rabbit",
                        Price= 55.55M
                    },
                    new Product
                    {
                        Name = "Hat",
                        Price= 25.45M
                    },
                    new Product
                    {
                        Name = "Svengali Deck",
                        Price= 105.55M
                    },
                    new Product
                    {
                        Name = "Floating Hankerchief",
                        Price= 56.55M
                    },
                    new Product
                    {
                        Name = "Wand",
                        Price= 98.50M
                    },
                    new Product
                    {
                        Name = "Broomstick",
                        Price= 15.55M
                    },
                    new Product
                    {
                        Name = "Bang Gun",
                        Price= 45.25M
                    },
                    new Product
                    {
                        Name = "Cloak of Invisibility",
                        Price= 35.55M
                    },
                    new Product
                    {
                        Name = "Elder Wand",
                        Price= 45.55M
                    },
                    new Product
                    {
                        Name = "Resurrection Stone",
                        Price= 25.55M
                    }
                };

                context.Product.AddRange(products);

                var i = 0;
                context.OwnerInventory.AddRange(
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 20
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 50
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 100
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 150
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 40
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 10
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 5
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 0
                    },
                    new OwnerInventory
                    {
                        Product = products[i++],
                        StockLevel = 0
                    },
                    new OwnerInventory
                    {
                        Product = products[i],
                        StockLevel = 0
                    }
                );

                i = 0;
                var stores = new[]
                {
                    new Store
                    {
                        Name = "Melbourne CBD",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 15
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 10
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 5
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 1
                            },
                            new StoreInventory
                            {
                                Product = products[i++],
                                StockLevel = 1
                            },
                            new StoreInventory
                            {
                                Product = products[i],
                                StockLevel = 1
                            },
                        }
                    },
                    new Store
                    {
                        Name = "North Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[0],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "East Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[1],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "South Melbourne",
                        StoreInventory =
                        {
                            new StoreInventory
                            {
                                Product = products[2],
                                StockLevel = 5
                            }
                        }
                    },
                    new Store
                    {
                        Name = "West Melbourne"
                    }
                };

                context.Store.AddRange(stores);

                context.SaveChanges();
            }
        }
    }

    
}
