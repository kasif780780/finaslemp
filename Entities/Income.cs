using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Income
    {
        [Key]
        public int IncomeID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public decimal? Amount { get; set; }
    }
}