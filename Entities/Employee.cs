using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Employee
    { 
        [Key]
        public int EmployeeID { get; set; }
        [Display(Name ="Employee Name")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name ="Date Of Joining")]
        public DateTime DateofJoin { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Phone")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]

        public string Email { get; set; }
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }
        [Display(Name ="Address")]
        public string Address { get; set; }
        [Display(Name ="Gender")]
        public string Gender { get; set; }
        [Display(Name ="Passport Number")]
        public string PassportNo { get; set; }
        [Display(Name ="Passport Expiry Date")]
        public string PassportExpairyDate { get; set; }
        [Display(Name ="Nationality")]
        public string Nationality { get; set; }

        [Display(Name ="Religion")]
        public string Religion { get; set; }
        [Display(Name ="MartialStatus")]

        public string MartialStatus { get; set; }
        [Display(Name ="Employment of Spouse")]
        public string EmploymentofSpouse { get; set; }

        [Display(Name ="Number Of Children")]
        public string NofChildren { get; set; }

        //Emergency Emp Contact
        [Display(Name = "Primary Name")]
        public string PrimaryName { get; set; }
        [Display(Name = "RelationShip")]
        public string RelationShip { get; set; }
        [Display(Name = "Primary Phone")]
        public string PrimaryPhone { get; set; }

        [Display(Name = "Secondary Name")]

        public string SecondaryName { get; set; }

        [Display(Name = "RelationShip")]
        public string SecondaryRelationShip { get; set; }
        [Display(Name = "Phone")]
        public string SecondaryPhone { get; set; }

        [Display(Name = "Photo")]
        public string EmployeePhoto { get; set; }
        public string Resume { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }



        [Display(Name = "UserRoles")]
        public string UserRoles { get; set; }

        public int DepartmentID { get; set; }
        public int DesignationID { get; set; }

        public virtual Department Department { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual IEnumerable<Payroll> Payrolls { get; set; }



        public virtual IEnumerable<Termination> Terminations { get; set; }
        public virtual IEnumerable<Ticket> Tickets { get; set; }

        public virtual IEnumerable<Leave> Leaves { get; set; }

    }
}