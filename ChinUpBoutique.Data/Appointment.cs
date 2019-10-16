using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ChinUpBoutique.Data
{
    public enum AppointmentType { Casual = 1, Business, Evening, SpecialEvent }
    public class Appointment
    {   [Key]
        public int AppointmentId { get; set; }
        [Required]
        public int UserId { get; set; }
        
        public int StylistId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public string Comment { get; set; }
        [Required]

        public AppointmentType TypeOfAppointment { get; set; }

    }
}
 