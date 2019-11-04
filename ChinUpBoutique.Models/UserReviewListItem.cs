using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class UserReviewListItem
    {
        [Display(Name = "Stylist ID")]
        public string StylistID { get; set; }
        [Display(Name = "Review ID")]
        public int ReviewID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
