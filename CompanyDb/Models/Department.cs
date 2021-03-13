using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDb.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        
        
    }
}