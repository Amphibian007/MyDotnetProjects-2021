using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name should be entered")] 
        public string Name { get; set; }
        [Required(ErrorMessage ="Salary should be entered")]
        [Range(10000,100000,ErrorMessage ="Salary range is 10000 to 100000")]
        public decimal? Salary { get; set; }
        [Required(ErrorMessage = "Experience should be entered")]
        [Range(2, 10, ErrorMessage = "Experience should be from 2 to 10")]
        public int? Experience { get; set; }
        [Required(ErrorMessage ="Genre should be selected from the dropdown")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
