using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        [Display(Name ="Department Name")]
        public string Name { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; }
    }
}