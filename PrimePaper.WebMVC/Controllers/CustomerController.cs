﻿using Microsoft.AspNet.Identity;
using PrimePaper.Models;
using PrimePaper.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimePaper.WebMVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            var model = service.GetCustomers();

            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Your product was created. ";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be created.");

            return View(model);

        }
        public ActionResult Details(int id)
        {
            var svc = CreateCustomerService();
            var model = svc.GetCustomerById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCustomerService();
            var detail = service.GetCustomerById(id);
            var model =
                new CustomerEdit
                {
                    CustomerID = detail.CustomerID,
                    BusinessName = detail.BusinessName,
                    Address = detail.Address,
                    CellPhoneNumber = detail.CellPhoneNumber
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateCustomerService();

            if (service.UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Your customer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your customer could not be updated.");
            return View();
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateCustomerService();

            service.DeleteCustomer(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}