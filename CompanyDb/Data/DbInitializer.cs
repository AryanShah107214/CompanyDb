using CompanyDb.Data;
using CompanyDb.Models;
using System;
using System.Linq;


namespace CompanyDb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

           // Checks if there are employees
            if (context.Stores.Any())
            {
                return;   // and if there are, it returns them
            }

            var stores = new Store[]
           {
                new Store{StoreLocation="Onehunga",StoreAddress="5 Brookyln Street"},
                new Store{StoreLocation="New Lynn",StoreAddress="456343 Cyrus Avenue"},
                new Store{StoreLocation="Avondale",StoreAddress="954 Sophie Place"},
                new Store{StoreLocation="Kelston",StoreAddress="6942 Tesla Road "},
           };
            context.Stores.AddRange(stores);
            context.SaveChanges();

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




            var employees = new Employee[]//creates list of employees with their information to include on the website
            {
                new Employee{First_Middle_Name="Steven",LastName="King",HireDate=DateTime.Parse("2003-06-17"),StoreID=1,DepartmentID=1},
                new Employee{First_Middle_Name="Neena",LastName="Kocchar",HireDate=DateTime.Parse("2007-09-04"),StoreID=1,DepartmentID=5},
                new Employee{First_Middle_Name="Lex",LastName="De Haan",HireDate=DateTime.Parse("2006-09-03"),StoreID=1,DepartmentID=4},
                new Employee{First_Middle_Name="Alexander",LastName="Hunold",HireDate=DateTime.Parse("2011-01-12"),StoreID=1,DepartmentID=3},
                new Employee{First_Middle_Name="Bruce",LastName="Ernest",HireDate=DateTime.Parse("2017-03-04"),StoreID=4,DepartmentID=6},
                new Employee{First_Middle_Name="David",LastName="Austin",HireDate=DateTime.Parse("2016-03-11"),StoreID=3,DepartmentID=2},
                new Employee{First_Middle_Name="Valli",LastName="Pataballa",HireDate=DateTime.Parse("2014-02-01"),StoreID=1,DepartmentID=1},
                new Employee{First_Middle_Name="Nino",LastName="Olivetto",HireDate=DateTime.Parse("2020-03-10"),StoreID=2,DepartmentID=4}
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();






        }

    }
}
