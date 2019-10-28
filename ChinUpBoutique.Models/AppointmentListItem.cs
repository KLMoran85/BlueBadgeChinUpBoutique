using ChinUpBoutique.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Models
{
    public class AppointmentListItem
    {   [Display(Name = "Appointment ID")]
        public int AppointmentID { get; set; }
        [Display(Name = "Customer ID")]
        public Guid? CustomerID { get; set; }
        [Required]
        [Display(Name = "Customer's First Name")]
        public string CustomerFirstName { get; set; }
        [Required]
        [Display(Name = "Customer's Last Name")]
        public string CustomerLastName { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Customer's Phone Number")]
        public string PhoneNumber { get; set; }
        [Display (Name = "Stylist ID")]
        public string StylistID { get; set; }
        [Required]
        [Display(Name = "Requested date and time of appointment")]
        public DateTime DateOfAppointment { get; set; }

        [Display(Name="Appointment Type")]
        public AppointmentType TypeOfAppointment { get; set; }
        [Display (Name = "Customer Comments")]
        public string Comment { get; set; }
    }
  
}
