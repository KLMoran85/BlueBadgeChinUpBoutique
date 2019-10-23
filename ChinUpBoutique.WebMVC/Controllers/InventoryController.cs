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
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new InventoryService(userId);
            var model = service.GetInventory();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryCreate model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new InventoryService(userId);

            service.CreateInventory(model);

            return RedirectToAction("Index");
            
        }
    }
}