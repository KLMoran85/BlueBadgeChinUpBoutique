﻿using ChinUpBoutique.Data;
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
        public IEnumerable<AppointmentListItem> GetAppointments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Appointments
                        .Where(e => e.CustomerID == _userId)
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
                        .Single(e => e.CustomerID == _userId);

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
    }
}




