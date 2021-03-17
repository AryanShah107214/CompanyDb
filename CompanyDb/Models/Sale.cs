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
        [Display(Name = "Item Name")]
        public int SaleName { get; set; }//stores name of the item sold

        public decimal ItemCost { get; set; }

        public int EmployeeID { get; set; }//one employee can make many sales/sell many items

        public int StoreID { get; set; }//one store can have many sales/items sold
        
        public Employee Employee { get; set; }
        public Store Store { get; set; }
        
        
    }
}
