using ChinUpBoutique.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class Stylists
    {
        public string StylistID { get; set; }
        public virtual ApplicationUser StylistUser { get; set; }
        public string StylistUserName { get; set; }

    }
}
