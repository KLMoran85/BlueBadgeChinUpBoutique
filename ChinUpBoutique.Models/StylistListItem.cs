using ChinUpBoutique.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class StylistListItem
    {
        [Display(Name = "Stylist ID")]
        public string StylistID { get; set; }
        //public ApplicationUser StylistUser { get; set; }
        [Display(Name = "UserName")]
        public string StylistUserName { get; set; }
        //public int SelectedStylistID { get; set; }
        [Display(Name = "First Name")]
        public string StylistFirstName { get; set; }
        [Display(Name = "Last Name")]
        public string StylistLastName { get; set; }
        public byte[] Photo { get; set; }
    }
}
