using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly StoreContext _context;

        public IndexModel(StoreContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Employee> Employees { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Employee> employeesIQ = from e in _context.Employees
                                             select e;
            if (!String.IsNullOrEmpty(searchString))
            {
                employeesIQ = employeesIQ.Where(e => e.LastName.Contains(searchString)
                                       || e.First_Middle_Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    employeesIQ = employeesIQ.OrderByDescending(e => e.LastName);
                    break;
                case "Date":
                    employeesIQ = employeesIQ.OrderBy(e => e.HireDate);
                    break;
                case "date_desc":
                    employeesIQ = employeesIQ.OrderByDescending(e => e.HireDate);
                    break;
                default:
                    employeesIQ = employeesIQ.OrderBy(e => e.LastName);
                    break;
            }

            Employees = await employeesIQ.AsNoTracking().ToListAsync();
        }
    }
}

