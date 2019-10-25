using ChinUpBoutique.Data;
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
        ApplicationDbContext context;
        // GET: get all users, order alphebetically, display username, and role?
        //drop down to change role?
        public RoleController()
        {
            context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var users = context.Users.ToList();
            //users[0].Roles.ToList()[0].RoleId
            return View(users);
            //    if (!User.IsInRole("Admin"))
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            
            //else
            //{
            //    return RedirectToAction("View");
            //}

        }

        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}