using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.DepartmentsStores
{
    public class DeleteModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public DeleteModel(CompanyDb.Data.StoreContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DepartmentStore = await _context.DepartmentStore.FindAsync(id);

            if (DepartmentStore != null)
            {
                _context.DepartmentStore.Remove(DepartmentStore);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
