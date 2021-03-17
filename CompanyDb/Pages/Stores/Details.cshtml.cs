using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Stores
{
    public class DetailsModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public DetailsModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store = await _context.Stores.FirstOrDefaultAsync(m => m.StoreID == id);

            if (Store == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
