using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmpManager.Entities
{
    public class Asset
    {
        [Key]
        public int AssetID { get; set; }
        [Display(Name ="Product Name")]
        public string Name { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        [Display(Name ="Purchase From")]
        public string PurchaseFrom { get; set; }

        [Display(Name="Manufacturer")]
        public string Manufacturer { get; set; }
        [Display(Name="Model")]
        public string Model { get; set; }
        [Display(Name ="Serial No.")]
        public string SerialNo { get; set; }
        [Display(Name ="Supplier")]
        public string Supplier { get; set; }
        [Display(Name ="Amount")]
        public decimal Amount { get; set; }
        [Display(Name ="Tax")]
        public decimal Tax { get; set; }

    }
}