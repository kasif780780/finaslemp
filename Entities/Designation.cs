using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Designation
    {
        [Key]
        public int DesignationID { get; set; }
        [Display(Name="Designation")]
        public string Name { get; set; }

        public virtual IEnumerable<Employee> Employees { get; set; }

    }
}