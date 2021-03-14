using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDb.Models
{
    public class DepartmentStore
    {
        public int DepartmentStoreID { get; set; }
        public int DepartmentID { get; set; }
        public string StoreID { get; set; }

        public Department Department { get; set; }
        public Store Store { get; set; }
    }
}
