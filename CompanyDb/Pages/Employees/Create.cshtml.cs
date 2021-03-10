using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public CreateModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyEmployee = new Employee();

            if (await TryUpdateModelAsync<Employee>(
                emptyEmployee,
                "employee",   // Prefix for form value.
                e => e.First_Middle_Name, e => e.LastName, e => e.HireDate,e => e.StoreID))
            {
                _context.Employees.Add(emptyEmployee);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
