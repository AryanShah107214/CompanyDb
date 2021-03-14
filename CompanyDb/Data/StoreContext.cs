using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CompanyDb.Models;

namespace CompanyDb.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext (DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales{ get; set; }
        public DbSet<Store> Stores{ get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<Sale>().ToTable("Sale");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Department>().ToTable("Department");
        }

        public DbSet<CompanyDb.Models.DepartmentStore> DepartmentStore { get; set; }

    }
}
