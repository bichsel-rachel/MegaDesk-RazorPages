using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk
{
    public class IndexModel : PageModel
    {
        private readonly MegaDesk.Data.MegaDeskContext _context;

        public IndexModel(MegaDesk.Data.MegaDeskContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            Order = await _context.Order.ToListAsync();

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            IQueryable<Order> deskQuote = from s in _context.Order
                                             select s;

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

            Order = await deskQuote.AsNoTracking().ToListAsync();
        }
    }
}
