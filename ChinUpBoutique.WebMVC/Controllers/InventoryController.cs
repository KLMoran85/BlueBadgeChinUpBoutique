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
    [Authorize]
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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateInventoryService();

            if (service.CreateInventory(model))
            {
                TempData["SaveResult"] = "Your inventory item was created successfully";

                return RedirectToAction("Index");
            };
            return View(model);

            ModelState.AddModelError("", "Inventory could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.GetInventoryById(id);

            return View(model);
        }

        private InventoryService CreateInventoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            var service = new InventoryService(userId);
            return service;
        }

       
    }
}