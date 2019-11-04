using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Data
{
    public class Profile
    {
        [Key]
        [Display(Name = "Profile ID")]
        public int ProfileID { get; set; }
        [Display(Name = "User ID")]
        public string UserID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
    }
}
