using ChinUpBoutique.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class InventoryDetail
    {
        [Key]
        [Display(Name = "Item ID")]
        public int ItemID { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
        [Required]
        [Display(Name = "Sku Number")]
        public string SkuNumber { get; set; }
        [Required]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
        [Display(Name = "Item Price")]
        public double ItemPrice { get; set; }
        [Required]
        [Display(Name = "Item Type")]
        public ItemType TypeOfItem { get; set; }
        public byte[] Photo { get; set; }
    }
}
