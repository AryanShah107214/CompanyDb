using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyDb.Models.StoreViewModels
{
    public class HireDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? HireDate { get; set; }

        public int EmployeeCount { get; set; }
    }
}