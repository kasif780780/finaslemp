using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Payroll
    {
        [Key]
        public int PayrollID { get; set; }



        [Display(Name = "Employee Number")]
        public int EmployeeNumber { get; set; }
    
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PayrollDate { get; set; }
        public decimal Amount { get; set; }
        [Display(Name = "Payment Type")]
        public string PaymentType { get; set; }
        [Display(Name = "PF Contribution")]
        public bool IsPFContribution { get; set; }
        [Display(Name = "PF Number")]
        public string PFNumber { get; set; }
        [Display(Name = "ESI Contribution")]
        public bool IsESIContribution { get; set; }
        [Display(Name = "ESI Number")]
        public int EsiNumber { get; set; }
        public int EmployeeID { get; set; }

        [Display(Name ="House Rent Allowance")]
        public decimal HRT { get; set; }

        [Display(Name ="Medical Conveyance Allowance")]
        public decimal MCA { get; set; }

        [Display(Name ="Incentive")]
        public decimal Incentive { get; set; }

        #region
        //Deduction
        #endregion
        [Display(Name ="Income Tax")]
        public decimal IncomeTax { get; set; }
        [Display(Name = "Professional Tax")]
        public decimal PF { get; set; }

        public virtual Employee Employee { get; set; }


    }
}
