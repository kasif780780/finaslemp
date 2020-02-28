using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Termination
    {
        [Key]
        public int TerminationId { get; set; }

        
        public string TerminationEmp { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TerminationDate { get; set; }
        public string Reason { get; set; }
        public string NoticeDate { get; set; }
        public string Department { get; set; }
        public int EmployeeID { get; set; }
        public virtual Employee Employee { get; set; }

    }
}