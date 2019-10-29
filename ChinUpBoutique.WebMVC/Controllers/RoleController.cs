using ChinUpBoutique.Data;
using ChinUpBoutique.Models;
using ChinUpBoutique.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChinUpBoutique.WebMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        //ApplicationDbContext context;
        // GET: get all users, order alphebetically, display username, and role?
        //drop down to change role?
        //public RoleController()
        //{
        //    context = new ApplicationDbContext();
        //}
        public ActionResult Index()
        {

            var service = new RoleService();
            var usersToReturn = service.GetUserRoles();
            ViewBag.RoleNames = service.GetIdentityRoles().OrderByDescending(r => r.Name);
                
            return View(usersToReturn);
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string userId, string RoleId )
        {
            var service = new RoleService();
            service.EditIdentyRoles(userId, RoleId);

            return RedirectToAction("Index");
        }



    }
} 