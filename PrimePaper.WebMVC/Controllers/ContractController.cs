using Microsoft.AspNet.Identity;
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
    public class ContractController : Controller
    {
        // GET: Contract
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContractService(userId);
            var model = service.GetContracts();

            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateContractService();

            if (service.CreateContract(model))
            {
                TempData["SaveResult"] = "Your product was created. ";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Product could not be created.");

            return View(model);
        }

        private ContractService CreateContractService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContractService(userId);
            return service;
        }

    }
}