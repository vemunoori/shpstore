using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Groc.Areas.Identity.Data;
using Groc.Models;

namespace Groc.Areas.Orders
{
    public class DetailsModel : PageModel
    {
        private readonly Groc.Areas.Identity.Data.GrocIdentityDbContext _context;

        public DetailsModel(Groc.Areas.Identity.Data.GrocIdentityDbContext context)
        {
            _context = context;
        }

        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.User).FirstOrDefaultAsync(m => m.Id == id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
