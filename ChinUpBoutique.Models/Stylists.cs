using ChinUpBoutique.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ChinUpBoutique.Models
{
    public class Stylists
    {
        public string StylistID { get; set; }
        public ApplicationUser StylistUser { get; set; }
        public string StylistUserName { get; set; }
        public int SelectedStylistID { get; set; }
      

    }
}
