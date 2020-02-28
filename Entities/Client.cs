using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Client
    {
        [Key]
        public int ClientID  { get; set; }
        [Display(Name ="Fisrt Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }

        [Display(Name ="User Name")]
        public string Username { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Designation")]
        public string Designation { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        [Display(Name = "Company Name")]
        public string Company { get; set; }

        [Display(Name ="Bank Details")]
        public string BankDeatils { get; set; }

        public string ClientPhoto { get; set; }
    }
}