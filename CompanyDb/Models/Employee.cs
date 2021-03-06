using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDb.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string First_Middle_Name { get; set; }
        public DateTime HireDate { get; set; }

        public ICollection<Sale> Sales{ get; set; }


    }
}