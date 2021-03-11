using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDb.Models
{
    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int SaleID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public int ItemName { get; set; }//stores name of the item sold


        public int EmployeeID { get; set; }//stores EmployeeID to indetify which employee made the sale to know who to give the commission to.
        public int StoreID { get; set; }//This company has multiple stores so it is required to keep track of the storeID.
        public decimal ItemCost { get; set; }
        public Employee Employee { get; set; }
        public Store Store { get; set; }
        
    }
}
