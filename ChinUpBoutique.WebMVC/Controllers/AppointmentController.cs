using ChinUpBoutique.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChinUpBoutique.WebMVC.Controllers
{   [Authorize]
    public class AppointmentController : Controller
    {
        // GET: Appointment
        public ActionResult Index()
        {
            var model = new AppointmentListItem[0];
            return View(model);
        }

        public ActionResult Create()
        {
            return View(new AppointmentCreate());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppointmentCreate model)
        {
            if(ModelState.IsValid)
            {

            }
            return View(model);
        }
    }


}