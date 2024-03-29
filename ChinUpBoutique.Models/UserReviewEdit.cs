﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class UserReviewEdit
    {   [Key]
        [Display(Name = "Review ID")]
        public Guid OwnerID { get; set; }
        public int ReviewID { get; set; }
        [Display(Name = "Stylist ID")]
        public string StylistID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
