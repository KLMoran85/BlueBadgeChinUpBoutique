using ChinUpBoutique.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class InventoryCreate
    {   [Required]
        public string ItemName { get; set; }
        [Required]
        public string SkuNumber { get; set; }
        [Required]
        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }
        [Required]
        public ItemType TypeOfItem { get; set; }

    }
}
