﻿using ChinUpBoutique.Models;
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

        public ActionResult Edit(int id)
        {
            var service = CreateInventoryService();
            var detail = service.GetInventoryById(id);
            var model =
                new InventoryEdit
                {
                    ItemID = detail.ItemID,
                    ItemName = detail.ItemName,
                    SkuNumber = detail.SkuNumber,
                    ItemDescription = detail.ItemDescription,
                    ItemPrice = detail.ItemPrice
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, InventoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ItemID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateInventoryService();

            if (service.UpdateInventory(model))
            {
                TempData["SaveRestult"] = "Your Inventory item was updated.";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Inventory item could not be updated.");

            return View(model);

            
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.GetInventoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateInventoryService();

            service.DeleteInventory(id);

            TempData["SaveResult"] = "Your Inventory item was deleted";

            return RedirectToAction("Index");
        }


    }
}