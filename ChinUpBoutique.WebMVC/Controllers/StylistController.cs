using ChinUpBoutique.Models;
using ChinUpBoutique.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ApplicationServices;
using System.Web.Mvc;

namespace ChinUpBoutique.WebMVC.Controllers
{
    public class StylistController : Controller
    {
        // GET: Stylist
        public ActionResult Index()
        {
            var svc = new StylistsService(Guid.Parse(User.Identity.GetUserId()));
            var model = svc.GetListOfStylists();
            return View(model);
        }
        public ActionResult Details(Guid id)
        {
            var svc = new StylistsService(Guid.Parse(User.Identity.GetUserId()));
            var model = svc.GetStylistById(id);
            var profilesvc = new ProfilesService(Guid.Parse(User.Identity.GetUserId()));
            var userreviewsvc = new UserReviewService(Guid.Parse(User.Identity.GetUserId()));
            model.UserReviewListItem = userreviewsvc.GetUserReviewsByStylistID(id.ToString()).ToList();
            model.StylistProfile = profilesvc.GetProfileByUserID(id.ToString());
            return View(model);
        }

        public ActionResult Edit()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProfilesService(Guid.Parse(User.Identity.GetUserId()));
            var detail = service.GetProfileByUserID(userId.ToString());
            var model =
                new ProfileEdit
                {
                    UserID = detail.UserID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    PhoneNumber = detail.PhoneNumber,
                    Email = detail.Email
                   
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( ProfileEdit model)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            if (!ModelState.IsValid) return View(model);

            if(model.UserID !=userId.ToString())
            {
                ModelState.AddModelError("", "IDMismatch");
                return View(model);
            }

            var service = new ProfilesService(userId);

            if (service.UpdateProfile(model))
            {
                TempData["SaveResult"] = "Your Profile has been updated!";
                return RedirectToAction("Details", new {id=userId });
            }
            ModelState.AddModelError("", "Your Profile could not be updated.");
            return View(model);
        }


    }

}