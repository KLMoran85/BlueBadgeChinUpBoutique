using ChinUpBoutique.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class StylistDetail
    {
        [Display(Name = "Stylist ID")]
        public string StylistID { get; set; }
        public string StylistUserName { get; set; }
        public Profile StylistProfile{ get; set; }

    }
}
