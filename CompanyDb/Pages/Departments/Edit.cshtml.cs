﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Data;
using CompanyDb.Models;

namespace CompanyDb.Pages.Departments
{
    public class EditModel : PageModel
    {
        private readonly CompanyDb.Data.StoreContext _context;

        public EditModel(CompanyDb.Data.StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Department Department { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Department = await _context.Departments.FindAsync(id);

            if (Department == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var departmentToUpdate = await _context.Departments.FindAsync(id);

            if (departmentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Department>(
                departmentToUpdate,
                "department",
                d => d.DepartmentName, d => d.StoreID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool DepartmentExists(int id)
        {
            return _context.Departments.Any(d => d.DepartmentID == id);
        }
    }
}