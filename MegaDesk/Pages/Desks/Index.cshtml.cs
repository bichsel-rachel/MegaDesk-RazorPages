using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDesk
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public IndexModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public PaginatedList<Order> Order { get; set; }
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public SelectList LastName { get; set; }
        [BindProperty(SupportsGet = true)]
        public string OrderSurfaceMaterial { get; set; }
        public string NameSort { get; set; }
        public string DateSort { get; set; }



        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Order> deskQuote = from s in _context.Order
                                          select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                deskQuote = deskQuote.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString));

            }

            switch (sortOrder)
            {
                case "name_desc":
                    deskQuote = deskQuote.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    deskQuote = deskQuote.OrderBy(s => s.DateAdded);
                    break;
                case "date_desc":
                    deskQuote = deskQuote.OrderByDescending(s => s.DateAdded);
                    break;
                default:
                    deskQuote = deskQuote.OrderBy(s => s.LastName);
                    break;
            }



            //Order = await deskQuote.AsNoTracking().ToListAsync();
            int pageSize = 10;
            Order = await PaginatedList<Order>.CreateAsync(
            deskQuote.AsNoTracking(), pageIndex ?? 1, pageSize);



        }
    }
}
