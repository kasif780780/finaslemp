using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Setting
    {
        [Key]
        public int SettingID { get; set; }
        [Display(Name ="Company Name")]
        public string Name { get; set; }

        [Display(Name = "Contact Person")]
        public string Contact { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Company Country")]
        public string Country { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string Zipcode { get; set; }
    }
}