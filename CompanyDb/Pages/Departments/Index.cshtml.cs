using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Departments
{
    public class IndexModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public IndexModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        //public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Department> Departments { get; private set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Department> departmentsIQ = from d in _context.Departments
                                               select d;
            if (!String.IsNullOrEmpty(searchString))
            {
                departmentsIQ = departmentsIQ.Where(d => d.DepartmentName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    departmentsIQ = departmentsIQ.OrderByDescending(d => d.DepartmentName);
                    break;
            }

            int pageSize = 3;
            Departments = await PaginatedList<Department>.CreateAsync(
                departmentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
