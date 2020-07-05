using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeCRUDDemonstration.Models
{
    public class Employee
    {
        [Required(ErrorMessage ="Please Enter Employee ID")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Employee Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please Enter Employee Location")]
        public string Location { get; set; }

        [Required(ErrorMessage ="Please Enter Employee Salary")]
        public int Salary { get; set; }

        [Required(ErrorMessage ="Please Enter Department ID")]
        public int DeptId { get; set; }
    }
}