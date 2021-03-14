using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Stores
{
    public class EditModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public EditModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Store = await _context.Stores.FindAsync(id);

            if (Store == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var storeToUpdate = await _context.Stores.FindAsync(id);

            if (storeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Store>(
                storeToUpdate,
                "store",
                s => s.StoreLocation, s => s.ItemCost))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool StoreExists(string id)
        {
            return _context.Stores.Any(s => s.StoreID == id);
        }
    }
}
