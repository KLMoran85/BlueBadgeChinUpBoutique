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

            public bool CreateAppointment(AppointmentCreate model)
            {
                var entity =
                     new Appointment()
                     {

                        CustomerID = _userId;
                        DateOfAppointment = Datetime,
                        Comment = model.Comment,
                        CustomerFirstName = model.CustomerFirstName,
                        CustomerLastName = model.CustomerLastName,
                        AppointmentType = model.TypeOfAppointment
                    
                
                
                     }; 
                        
                     
            }
        }
    }
}
  


