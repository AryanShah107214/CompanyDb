using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Sales
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
        ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "First_Middle_Name");
        ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "StoreID");
            return Page();
        }

        [BindProperty]
        public Sale Sale { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sales.Add(Sale);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
