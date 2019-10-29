using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using ChinUpBoutique.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace ChinUpBoutique.WebMVC.Controllers
{   [Authorize]
    public class AppointmentController : Controller
    {
        // GET: Appointment
        //[Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService(userId);
            var model = service.GetAllAppointments();
            return View(model);
        }

        public ActionResult Create()
        {
            var service = new RoleService();
            var stylists = service.GetUserRoles().Where(e => e.RoleNames[0] == "StylistUser");
            ViewBag.GetListOfStylists = stylists;
            return View(new AppointmentCreate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);

                var service = CreateAppointmentService();
            
            if (service.CreateAppointment(model))
            {
                TempData["SaveResult"] = "Your appointment request has been submitted! One of our stylists will reach out to you shortly!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Appointment could not be submitted at this time.");

            return View(model);
        }

        public ActionResult Details (int id)
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentById(id);

            return View(model);
        }

        public ActionResult GetAppointmentsByStylists()
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentsByStylistID();

            return View(model.ToList());

        }


        private AppointmentService CreateAppointmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService(userId);
            return service;
        }
    }


}