using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Data
{
    public enum ItemType { Tops, Jackets, Pants, Jeans, Shorts, Skirts, Dresses, Suits, Shoes, Bags }
    public class Inventory
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        [Required]
        public string SkuNumber { get; set; }
        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }
        [Required]
        public ItemType TypeOfItem { get; set; }

    }
}
