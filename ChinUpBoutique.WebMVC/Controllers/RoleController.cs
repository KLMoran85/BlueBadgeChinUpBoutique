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
            //var appUsers = context.Users.ToList();
            //var usersToReturn = new List<UserRole>();
            //foreach (var u in appUsers)
            //{
            //    using (var m = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context)))
            //    {
            //        var rolesForUser = m.GetRoles(u.Id);

            //        var user = new UserRole
            //        {
            //            UserId = u.Id,
            //            UserName = u.UserName,
            //            Email = u.Email,
            //            RoleNames = rolesForUser
            //        };

            //        usersToReturn.Add(user);
            //    };
            //}

            var usersToReturn = new RoleService().GetUserRoles();
            
                
            //users[0].Roles.ToList()[0].RoleId
            return View(usersToReturn);
            //    if (!User.IsInRole("Admin"))
            //    {
            //        return RedirectToAction("Index", "Home");
            //    }
            
            //else
            //{
            //    return RedirectToAction("View");
            //}

        }

        public ActionResult Edit(string userId)
        {
            var Role = new IdentityRole();
            return View(Role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            //context.Roles.Add(Role);
            //context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}