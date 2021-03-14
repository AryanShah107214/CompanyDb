using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDb.Models
{
    public class Store
    {
        public string StoreID { get; set; }
        public string StoreLocation { get; set; }
        public decimal ItemCost { get; set; }
        public int EmployeeID { get; set; }
       
        public Employee Employee { get; set; }
        public Sale Sale { get; set; }
        public Department Department { get; set; }
    }
}
