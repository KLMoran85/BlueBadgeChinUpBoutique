using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    
    public class AppointmentCreate
    {   [Required]
        [Display(Name = "Customer's First Name")]
        public string CustomerFirstName { get; set; }
        [Required]
        [Display(Name = "Customer's Last Name")]
        public string CustomerLastName { get; set; }
        public string EmailAddress { get; set; }
        [Required]
      
        public string PhoneNumber { get; set; }
        [Required]
        [Display (Name = "Choose a Stylist")] 
        public string StylistID { get; set; }
        [Required]
        [Display(Name = "Requested date and time of appointment")]
      
        public DateTime DateOfAppointment { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Please enter at least 5 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Please provide your stylist with sizing and any other details that you would like for them to know")]
        public string Comment { get; set; }
        [Required]
        public AppointmentType TypeOfAppointment { get; set; }
    }
}
