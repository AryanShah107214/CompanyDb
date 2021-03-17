using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Sales
{
    public class DetailsModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public DetailsModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        public Sale Sale { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale = await _context.Sales
                .Include(s => s.Employee)
                .Include(s => s.Store).FirstOrDefaultAsync(m => m.SaleID == id);

            if (Sale == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
