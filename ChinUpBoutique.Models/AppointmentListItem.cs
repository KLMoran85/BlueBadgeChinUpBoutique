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
    //public enum AppointmentType { Casual = 1, Business, Evening, SpecialEvent }
    public class AppointmentListItem
    {
        public int AppointmentID { get; set; }
        public int UserID { get; set; }
        [Required]
        public string CustomerFirstName { get; set; }
        [Required]
        public string CustomerLastName { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Appointment Type")]
        public AppointmentType TypeOfAppointment { get; set; }
        public string Comment { get; set; }
    }
  
}
