using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Magic_Inventory.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Magic_Inventory.Controllers
{
    public class OwnerController : Controller
    {
        private readonly InventoryContext _context;

        public OwnerController(InventoryContext context)
        {
            _context = context;
        }


        // Auto-parsed variables coming in from the request - there is a form on the page to send this data.
        public async Task<IActionResult> Index(string productName)
        {
            // Eager loading the Product table - join between OwnerInventory and the Product table.
            var query = _context.OwnerInventory.Include(x => x.Product).Select(x => x);

            if (!string.IsNullOrWhiteSpace(productName))
            {
                // Adding a where to the query to filter the data.
                // Note for the first request productName is null thus the where is not always added.
                query = query.Where(x => x.Product.Name.Contains(productName));

                // Storing the search into ViewBag to populate the textbox with the same value for convenience.
                ViewBag.ProductName = productName;
            }

            // Adding an order by to the query for the Product name.
           //// query = query.OrderBy(x => x.ProductID);

            // Passing a List<OwnerInventory> model object to the View.
            return View(await query.ToListAsync());
        }


        public String Welcome(){
            return "this is a owner page";
        }
    }
}
