using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace EmpManager.Entities
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
    

        public DateTime ComingTime { get; set; }


        [DisplayName("Date")]
        public DateTime DateOfDay { get; set; }

        public DateTime? LeaveTime { get; set; }

        public int EmployeeID { get; set; }
    }
}