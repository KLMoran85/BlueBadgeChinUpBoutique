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
                     EmailAddress = model.EmailAddress,
                     PhoneNumber = model.PhoneNumber

                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Appointments.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<AppointmentListItem> GetAppointmentsByStylistID()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Appointments
                        .Where(e => e.StylistID == _userId.ToString())
                        .Select(
                        e =>
                                new AppointmentListItem
                                {
                                    AppointmentID = e.AppointmentID,
                                    DateOfAppointment = e.DateOfAppointment,
                                    StylistID = e.StylistID,
                                    Comment = e.Comment,
                                    CustomerFirstName = e.CustomerFirstName,
                                    CustomerLastName = e.CustomerLastName,
                                    TypeOfAppointment = e.TypeOfAppointment,
                                    EmailAddress = e.EmailAddress,
                                    PhoneNumber = e.PhoneNumber,
                                    CustomerID = e.CustomerID

                                }
                            );
                return query.ToArray();
                                
            }
        }

        public AppointmentDetail GetAppointmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appointments
                        .Single(e => e.AppointmentID == id);

                        return
                            new AppointmentDetail
                            {
                                AppointmentID = entity.AppointmentID,
                                DateOfAppointment = entity.DateOfAppointment,
                                StylistID = entity.StylistID,
                                Comment = entity.Comment,
                                CustomerFirstName = entity.CustomerFirstName,
                                CustomerLastName = entity.CustomerLastName,
                                TypeOfAppointment = entity.TypeOfAppointment,
                                EmailAddress = entity.EmailAddress,
                                PhoneNumber = entity.PhoneNumber,
                                CustomerID = entity.CustomerID
                            };
            }
        }

        

        public IEnumerable<AppointmentListItem> GetAllAppointments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                       .Appointments
                       .Select(e =>
                            new AppointmentListItem
                            {
                                AppointmentID = e.AppointmentID,
                                DateOfAppointment = e.DateOfAppointment,
                                StylistID = e.StylistID,
                                Comment = e.Comment,
                                CustomerFirstName = e.CustomerFirstName,
                                CustomerLastName = e.CustomerLastName,
                                TypeOfAppointment = e.TypeOfAppointment,
                                EmailAddress = e.EmailAddress,
                                PhoneNumber = e.PhoneNumber,
                                CustomerID = e.CustomerID
                            }

                         );
                return query.ToArray();
            }
        }

        public bool UpdateAppointment(AppointmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appointments
                        .Single(e => e.AppointmentID == model.AppointmentID);

                entity.AppointmentID = model.AppointmentID;
                entity.DateOfAppointment = model.DateOfAppointment;
                entity.CustomerFirstName = model.CustomerFirstName;
                entity.CustomerLastName = model.CustomerLastName;
                entity.EmailAddress = model.EmailAddress;
                entity.PhoneNumber = model.PhoneNumber;
                entity.TypeOfAppointment = model.TypeOfAppointment;
                entity.Comment = model.Comment;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteAppointment(int AppointmentID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Appointments
                        .Single(e => e.AppointmentID == AppointmentID);
                ctx.Appointments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}




