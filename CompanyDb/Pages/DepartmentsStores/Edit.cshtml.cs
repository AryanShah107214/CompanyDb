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

namespace CompanyDb.Pages.DepartmentsStores
{
    public class EditModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public EditModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DepartmentStore DepartmentStore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DepartmentStore = await _context.DepartmentStore
                .Include(d => d.Department)
                .Include(d => d.Store).FirstOrDefaultAsync(m => m.DepartmentStoreID == id);

            if (DepartmentStore == null)
            {
                return NotFound();
            }
           ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
           ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "StoreID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DepartmentStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentStoreExists(DepartmentStore.DepartmentStoreID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DepartmentStoreExists(int id)
        {
            return _context.DepartmentStore.Any(e => e.DepartmentStoreID == id);
        }
    }
}
