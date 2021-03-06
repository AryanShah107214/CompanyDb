using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyDb.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public int ItemName { get; set; }//stores name of the item sold
        public int EmployeeID { get; set; }//stores EmployeeID to indetify which employee made the sale to know who to give the commission to.
        public int StoreID { get; set; }//This company has multiple stores so it is required to keep track of the storeID.

        public Employee Employee { get; set; }
    }
}
