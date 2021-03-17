using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Sales
{
    public class EditModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public EditModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sale Sale { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Sale = await _context.Sales
                .Include(s => s.Employee)
                .Include(s => s.Store).FirstOrDefaultAsync(m => m.SaleID == id);

            if (Sale == null)
            {
                return NotFound();
            }
           ViewData["EmployeeID"] = new SelectList(_context.Employees, "EmployeeID", "First_Middle_Name");
           ViewData["StoreID"] = new SelectList(_context.Stores, "StoreID", "StoreID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(Sale.SaleID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SaleExists(int id)
        {
            return _context.Sales.Any(e => e.SaleID == id);
        }
    }
}
