using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Data
{
    public class UserReview
    {   
        [Key]
        public int ReviewID { get; set; }
        [ForeignKey("StylistUser")]
        public string StylistID { get; set; }
        public virtual ApplicationUser StylistUser { get; set; }

        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
