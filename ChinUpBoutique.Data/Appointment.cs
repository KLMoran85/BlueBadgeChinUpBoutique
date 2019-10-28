using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChinUpBoutique.Data
{ 
    public enum AppointmentType
    {[Display(Name = "Casual")]
        Casual,
        [Display(Name = "Business")]
        Business,

        [Display(Name = "Evening")]
        Evening,
        [Display(Name = "Special Event")]
        SpecialEvent
    }
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required]
        public Guid? CustomerID { get; set; }
        [ForeignKey("StylistUser")]
        public string StylistID { get; set; }
        public virtual ApplicationUser StylistUser { get; set; }
        [Required]
        public DateTime DateOfAppointment { get; set; }
        [Required]
        [Display(Name = "Your Comments")]
        public string Comment { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        public string EmailAddress { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public AppointmentType TypeOfAppointment { get; set; } 

    }
}
 