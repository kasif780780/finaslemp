using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class LeaveType
    {
        [Key]
        public int LeaveTypeID { get; set; }

        [Display(Name ="Leave Type")]
        public string Type { get; set; }
        [Display(Name ="Number Of Days")]
        public int Day { get; set; }

        public virtual IEnumerable<Leave> Leaves { get; set; }

    }
}