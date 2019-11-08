using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using ChinUpBoutique.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChinUpBoutique.WebMVC.Controllers
{   [Authorize]
    public class UserReviewController : Controller
    {
        // GET: UserReview
        [Authorize(Roles = "Admin, StylistUser")]
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new UserReviewService(userId);
            var model = service.GetUserReviews();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string id, string title, string content)
        {
            if (!ModelState.IsValid) return View();
            {
                var service = CreateUserReviewService();

                if (service.CreateUserReview(new UserReviewCreate { StylistID = id, Title = title, Content = content}))
                {
                    TempData["SaveResult"] = "Your review was created!";
                    return RedirectToAction("Details", "Stylist", new { id = id });
                };

                ModelState.AddModelError("", "Note could not be created.");

                return View();
            }
          
        }

        public ActionResult Details(int id)
        {
            var svc = CreateUserReviewService();
            var model = svc.GetUserReviewById(id);

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var service = CreateUserReviewService();
            var detail = service.GetUserReviewById(id);
            var model =
                new UserReviewEdit
                {   OwnerID = detail.OwnerID,
                    ReviewID = detail.ReviewID,
                    StylistID = detail.StylistID,
                    Title = detail.Title,
                    Content = detail.Content,

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserReviewEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            
             if (model.ReviewID != id)
             {
               ModelState.AddModelError("", "Id Mismatch");
               return View(model);
             }
            

            var service = CreateUserReviewService();

            if (service.UpdateUserReview(model))
            {
                TempData["SaveResult"] = "Your review was updated.";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your review could not be updated.");

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateUserReviewService();
            var model = svc.GetUserReviewById(id);

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateUserReviewService();

            service.DeleteUserReview(id);

            TempData["SaveResult"] = "Your review was deleted.";

            return RedirectToAction("Index");
        }

        private UserReviewService CreateUserReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new UserReviewService(userId);
            return service;
        }
    }
    
}