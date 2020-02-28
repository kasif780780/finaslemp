using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        [Display(Name = "Currency")]
        public string Currency { get; set; }
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
        [Display(Name = "Purpose")]
        public string Purpose { get; set; }
        [Display(Name = "Date of Spend")]
        [DataType(DataType.Date)]
        public DateTime DateOfSpend { get; set; }

        [Display(Name = "Marchant")]
        public string Marchant { get; set; }
        [Display(Name = "Categories")]
        public string Category { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}