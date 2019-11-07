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
        [Authorize(Roles = "Admin, StylistUser")]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AppointmentService(userId);
            var model = service.GetAllAppointments();
            return View(model);
        }

        public ActionResult Create()
        {
            var service = new StylistsService(Guid.Parse(User.Identity.GetUserId()));
            var stylists = service.GetListOfStylists();
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
                return RedirectToAction("Index","Inventory");
            };

            ModelState.AddModelError("", "Appointment could not be submitted at this time.");

            return View(model);
        }
        [Authorize(Roles = "Admin, StylistUser")]
        public ActionResult Details(int id)
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentById(id);

            return View(model);
        }
        [Authorize(Roles = "Admin, StylistUser")]
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
        [Authorize(Roles = "Admin, StylistUser")]
        public ActionResult Edit(int id)
        {
            var service = CreateAppointmentService();
            var detail = service.GetAppointmentById(id);
            var model =
                new AppointmentEdit
                {
                    AppointmentID = detail.AppointmentID,
                    DateOfAppointment = detail.DateOfAppointment,
                    CustomerFirstName = detail.CustomerFirstName,
                    CustomerLastName = detail.CustomerLastName,
                    EmailAddress = detail.EmailAddress,
                    PhoneNumber = detail.PhoneNumber,
                    TypeOfAppointment = detail.TypeOfAppointment,
                    Comment = detail.Comment
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, StylistUser")]
        public ActionResult Edit(int id, AppointmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AppointmentID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateAppointmentService();

            if (service.UpdateAppointment(model))
            {
                TempData["SaveResult"] = "Your Appointment was updated!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Appointment could not be updated!");
            return View(model);
        }
        [Authorize(Roles = "Admin, StylistUser")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAppointmentService();
            var model = svc.GetAppointmentById(id);

            return View(model);
        }
        [Authorize(Roles = "Admin, StylistUser")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAppointmentService();

            service.DeleteAppointment(id);

            TempData["SaveResult"] = "Your Appointment was deleted";

            return RedirectToAction("Index");
        }
    }


}