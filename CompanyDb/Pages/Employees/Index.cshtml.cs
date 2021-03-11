using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Employees
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

        public PaginatedList<Employee> Employees{ get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Employee> employeesIQ = from s in _context.Employees
                                             select s;
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

            int pageSize = 3;
            Employees = await PaginatedList<Employee>.CreateAsync(
                employeesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}


