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
        [Display(Name = "User Name")]
        public string StylistUserName { get; set; }
        [Display(Name = "Profile")]
        public Profile StylistProfile{ get; set; }

        public List<UserReviewListItem> UserReviewListItem { get; set; }

    }
}
