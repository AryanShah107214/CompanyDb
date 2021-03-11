using CompanyDb.Models.StoreViewModels;
using CompanyDb.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyDb.Models;

namespace CompanyDb.Pages
{
    public class AboutModel : PageModel
    {
        private readonly StoreContext _context;

        public AboutModel(StoreContext context)
        {
            _context = context;
        }

        public IList<HireDateGroup> Employees { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<HireDateGroup> data =
                from employee in _context.Employees
                group employee by employee.HireDate into dateGroup
                select new HireDateGroup()
                {
                    HireDate = dateGroup.Key,
                    EmployeeCount = dateGroup.Count()
                };

            Employees = await data.AsNoTracking().ToListAsync();
        }
    }
}