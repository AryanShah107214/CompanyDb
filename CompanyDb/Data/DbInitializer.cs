﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompanyDb.Data;
using CompanyDb.Models;


namespace CompanyDb.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            //context.Database.EnsureCreated();

            // Checks if there are employees
            if (context.Employees.Any())
            {
                return;   // and if there are, it returns them
            }

            var employees = new Employee[]//creates list of employees with their information to include on the website
            {
                new Employee{EmployeeID=1, First_Middle_Name="Steven",LastName="King",HireDate=DateTime.Parse("2003-06-17"),StoreID=1},
                new Employee{EmployeeID=2,First_Middle_Name="Neena",LastName="Kocchar",HireDate=DateTime.Parse("2007-09-04"),StoreID=1},
                new Employee{EmployeeID=3,First_Middle_Name="Lex",LastName="De Haan",HireDate=DateTime.Parse("2006-09-03"),StoreID=1},
                new Employee{EmployeeID=4,First_Middle_Name="Alexander",LastName="Hunold",HireDate=DateTime.Parse("2011-01-12"),StoreID=1},
                new Employee{EmployeeID=5,First_Middle_Name="Bruce",LastName="Ernest",HireDate=DateTime.Parse("2017-03-04"),StoreID=4},
                new Employee{EmployeeID=6,First_Middle_Name="David",LastName="Austin",HireDate=DateTime.Parse("2016-03-11"),StoreID=3},
                new Employee{EmployeeID=7,First_Middle_Name="Valli",LastName="Pataballa",HireDate=DateTime.Parse("2014-02-01"),StoreID=1},
                new Employee{EmployeeID=8,First_Middle_Name="Nino",LastName="Olivetto",HireDate=DateTime.Parse("2020-03-10"),StoreID=2}
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            var stores = new Store[]
            {
                new Store{StoreLocation="Onehunga"},
                new Store{StoreLocation="New Lynn"},
                new Store{StoreLocation="Avondale"},
                new Store{StoreLocation="Kelston"},
                new Store{StoreLocation="Glen Eden"},
                new Store{StoreLocation="Glendene"},
                new Store{StoreLocation="Henderson"}
            };

            context.Stores.AddRange(stores);
            context.SaveChanges();

            var sales = new Sale[]
            {
                new Sale{SaleID=1,StoreID=1050},
                new Sale{SaleID=1,StoreID=4022},
                new Sale{SaleID=1,StoreID=4041},
                new Sale{SaleID=2,StoreID=1045},
                new Sale{SaleID=2,StoreID=2021},
                new Sale{SaleID=2,StoreID=3141},
                new Sale{SaleID=3,StoreID=1050},
                new Sale{SaleID=4,StoreID=1050},
                new Sale{SaleID=4,StoreID=4022},
                new Sale{SaleID=5,StoreID=4041},
                new Sale{SaleID=6,StoreID=1045},
                new Sale{SaleID=7,StoreID=3141},
            };
            context.Sales.AddRange(sales);
            context.SaveChanges();

            if (context.Departments.Any())
            {
                return;  
            }

            var departments = new Department[]
            {
                new Department{DepartmentName="Men's Clothing",NumberOfEmployees=5},
                new Department{DepartmentName="Women's Clothing",NumberOfEmployees=7},
                new Department{DepartmentName="Children's CLothing",NumberOfEmployees=3},
                new Department{DepartmentName="Gadgets and Toys",NumberOfEmployees=6},
                new Department{DepartmentName="Holiday Decorations etc",NumberOfEmployees=2},

            };
            context.Departments.AddRange(departments);
            context.SaveChanges();

            

        }
    }
}
