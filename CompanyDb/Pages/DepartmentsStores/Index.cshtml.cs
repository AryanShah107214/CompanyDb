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
    public class IndexModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public IndexModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        public IList<DepartmentStore> DepartmentStore { get;set; }

        public async Task OnGetAsync()
        {
            DepartmentStore = await _context.DepartmentStore
                .Include(d => d.Department)
                .Include(d => d.Store).ToListAsync();
        }
    }
}
