using ChinUpBoutique.Models;
using ChinUpBoutique.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChinUpBoutique.WebMVC.Controllers
{
    public class StylistController : Controller
    {
        // GET: Stylist
        public ActionResult Index()
        {
            var model = new StylistListItem[0];
            return View();
        }
        public ActionResult Details(Guid id)
        {
            var svc = new StylistsService(Guid.Parse(User.Identity.GetUserId()));
            var model = svc.GetStylistById(id);
            var profilesvc = new ProfilesService(Guid.Parse(User.Identity.GetUserId()));
            model.StylistProfile = profilesvc.GetProfileByUserID(id.ToString());
            return View(model);
        }

        
    }

}