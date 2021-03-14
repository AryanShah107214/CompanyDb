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
    public class DetailsModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public DetailsModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

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
    }
}
