using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDb.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }//The PK

        
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string First_Middle_Name { get; set; }
        
        [Required]//Tells us it is required i.e. can not be NULL
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        
        
        
        [Display(Name ="Store Location")]
        public int StoreID { get; set; }
        
        [Display(Name = "Department Name")]
        public int DepartmentID { get; set; }
        
        public Department Department { get; set; }
        public Store Store { get; set; }
    }
}