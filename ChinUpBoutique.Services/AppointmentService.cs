using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinUpBoutique.Services
{
    public class AppointmentService
    {
        private readonly Guid _userId;

        public AppointmentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAppointment(AppointmentCreate model)
        {
            var entity =
                 new Appointment()
                 {

                     CustomerID = _userId,
                     DateOfAppointment = model.DateOfAppointment,
                     StylistID = model.StylistID,
                     Comment = model.Comment,
                     CustomerFirstName = model.CustomerFirstName,
                     CustomerLastName = model.CustomerLastName,
                     TypeOfAppointment = model.TypeOfAppointment,
                     EmailAddress = model.EmailAddress



                 };

                using (var ctx = new ApplicationDbContext())
            {
                ctx.Appointments.Add(entity);
                return ctx.SaveChanges() == 1;
            }


        }
    }
}

  


