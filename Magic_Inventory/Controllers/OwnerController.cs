using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Magic_Inventory.Data;
using Microsoft.EntityFrameworkCore;
using Magic_Inventory.Utility;
using Magic_Inventory.ViewModel;
using Magic_Inventory.Models;


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
        public async Task<IActionResult> Index(
            string sortOrder, string currentFilter,
            string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["QtySortParm"] = sortOrder == "Qty" ? "qty_desc" : "Qty";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;



            // Eager loading the Product table - join between OwnerInventory and the Product table.
            var query = _context.OwnerInventory.Include(x => x.Product).Select(x => x);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(x => x.Product.Name.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    query = query.OrderByDescending(s => s.Product.Name);
                    break;
                case "Qty":
                    query = query.OrderBy(s => s.StockLevel);
                    break;
                case "date_desc":
                    query = query.OrderByDescending(s => s.StockLevel);
                    break;
                default:
                    query = query.OrderBy(s => s.Product.Name);
                    break;
            }

            int pageSize = 3;
            //var viewModel = new OwnerInventoryViewModel
            //{
            //    Inventory = await PaginatedList<OwnerInventory>
            //       .CreateAsync(query.AsNoTracking(), page ?? 1, pageSize)
            //};

            //// Passing a List<OwnerInventory> model object to the View.
            //return View(viewModel);

            return View(await PaginatedList<OwnerInventory>
                        .CreateAsync(query.AsNoTracking(), page ?? 1, pageSize));
        }


        public String Welcome()
        {
            return "this is a owner page";
        }
    }
}
