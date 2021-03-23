using System;
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
                new Employee{EmployeeID=1, First_Middle_Name="Steven",LastName="King",HireDate=DateTime.Parse("2003-06-17"),StoreID=1,DepartmentID=1},
                new Employee{EmployeeID=2,First_Middle_Name="Neena",LastName="Kocchar",HireDate=DateTime.Parse("2007-09-04"),StoreID=1,DepartmentID=5},
                new Employee{EmployeeID=3,First_Middle_Name="Lex",LastName="De Haan",HireDate=DateTime.Parse("2006-09-03"),StoreID=1,DepartmentID=4},
                new Employee{EmployeeID=4,First_Middle_Name="Alexander",LastName="Hunold",HireDate=DateTime.Parse("2011-01-12"),StoreID=1,DepartmentID=3},
                new Employee{EmployeeID=5,First_Middle_Name="Bruce",LastName="Ernest",HireDate=DateTime.Parse("2017-03-04"),StoreID=4,DepartmentID=6},
                new Employee{EmployeeID=6,First_Middle_Name="David",LastName="Austin",HireDate=DateTime.Parse("2016-03-11"),StoreID=3,DepartmentID=2},
                new Employee{EmployeeID=7,First_Middle_Name="Valli",LastName="Pataballa",HireDate=DateTime.Parse("2014-02-01"),StoreID=1,DepartmentID=1},
                new Employee{EmployeeID=8,First_Middle_Name="Nino",LastName="Olivetto",HireDate=DateTime.Parse("2020-03-10"),StoreID=2,DepartmentID=4}
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            if (context.Stores.Any())
            {
                return;   // and if there are, it returns them
            }

            var stores = new Store[]
            {
                new Store{StoreID=1,StoreLocation="Onehunga",StoreAddress="5 Brookyln Street"},
                new Store{StoreID=2,StoreLocation="New Lynn",StoreAddress="456343 Cyrus Avenue"},
                new Store{StoreID=3,StoreLocation="Avondale",StoreAddress="954 Sophie Place"},
                new Store{StoreID=4,StoreLocation="Kelston",StoreAddress="6942 Tesla Road "},
            };

            context.Stores.AddRange(stores);
            context.SaveChanges();


            if (context.Sales.Any())
            {
                return;   // and if there are, it returns them
            }
            var sales = new Sale[]
            {
                new Sale{SaleID=1,SaleName="Iphone 11 Pro Max",ItemCost=1699,StoreID=1},
                new Sale{SaleID=2,SaleName="Iphone 12 Pro Max",ItemCost=2300,StoreID=3},
                new Sale{SaleID=3,SaleName="Huawei Mate X2",ItemCost=3599,StoreID=4},
                new Sale{SaleID=4,SaleName="Samsung Galaxy Note 20 Ultra",ItemCost=1850,StoreID=2},
            };
            context.Sales.AddRange(sales);
            context.SaveChanges();

            if (context.Departments.Any())
            {
                return;  
            }

            var departments = new Department[]
            {
                new Department{DepartmentID=1,DepartmentName="Men's Clothing",NumberOfEmployees=5},
                new Department{DepartmentID=2,DepartmentName="Women's Clothing",NumberOfEmployees=7},
                new Department{DepartmentID=3,DepartmentName="Children's CLothing",NumberOfEmployees=3},
                new Department{DepartmentID=4,DepartmentName="Gadgets and Toys",NumberOfEmployees=6},
                new Department{DepartmentID=5,DepartmentName="Holiday Decorations etc",NumberOfEmployees=2},

            };
            context.Departments.AddRange(departments);
            context.SaveChanges();

            

        }
    }
}
