using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDb.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }//The PK
        [Required]//Tells us it is required i.e. can not be NULL
        [StringLength(50)]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
        [Required]
        public int NumberOfEmployees { get; set; }
        
        public Employee Employee { get; set; }
       
    }
}