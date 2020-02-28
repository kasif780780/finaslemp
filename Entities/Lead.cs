using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Lead
    {
        [Key]
        public int LeadID { get; set; }
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name ="Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Display(Name ="Status")]
        public string Status { get; set; }
        [Display(Name ="Lead Source")]
        public string LeadSources { get; set; }
        [Display(Name ="Enquiry For")]
        public string Enquiryfor { get; set; }
        [Display(Name ="Created Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    }
}