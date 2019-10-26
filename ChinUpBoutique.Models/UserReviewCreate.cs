using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class UserReviewCreate
    {
        [Required]
        public string StylistID { get; set; }
        [Required]
        public string Title { get; set; }
        [MaxLength(300, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }
    }
}

