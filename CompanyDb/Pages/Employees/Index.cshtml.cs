using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CompanyDb.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public IndexModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Store).ToListAsync();
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "DepartmentName");
            ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "StoreLocation");
        }
    }
}
