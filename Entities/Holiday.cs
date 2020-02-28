using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Holiday
    {
        [Key]
        public int HolidayID { get; set; }

        [Display(Name ="Title")]
     
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Holiday Date")]
        public DateTime Date { get; set; }
        [Display(Name ="Name")]
        public string Day { get; set; }
    }
}