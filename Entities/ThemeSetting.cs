using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class ThemeSetting
    {
        [Key]
        public int ThemeSettingID { get; set; }
        [Display(Name ="Website Name")]
        public string Name { get; set; }

        [Display(Name = "Website Logo")]
        public string Logo { get; set; }
        [Display(Name = "Website Fevicon")]
        public string Favicon { get; set; }
    }
}