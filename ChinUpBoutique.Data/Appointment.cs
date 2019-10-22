using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChinUpBoutique.Data
{ //{ Casual = 1, Business, Evening, SpecialEvent }
    public enum AppointmentType
    {[Display(Name = "First Value - Casual")]
        Casual,
        [Display(Name = "Second Value - Business")]
        Business,

        [Display(Name = "Third Value - Evening")]
        Evening,
        [Display(Name = "Fourth Value - Special Event")]
        SpecialEvent
    }
    public class Appointment
    {   [Key]
        public int AppointmentID { get; set; }
        [Required]
        public int CustomerID { get; set; }
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
        [Required]

        public AppointmentType TypeOfAppointment { get; set; } 

    }
}
 