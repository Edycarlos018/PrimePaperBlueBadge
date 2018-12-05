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
            //var customerService = CreateCustomerService();
            //var customer = customerService.GetCustomers();
            //ViewBag.customer = new SelectList(customer, "CustomerID", "BusinessName");
            var model = service.GetContracts();

            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            var customerService = CreateCustomerService();
            var productService = CreateProductService();
            ViewBag.CustomerID = new SelectList(customerService.GetCustomers(), "CustomerID", "BusinessName");
            ViewBag.ProductId = new SelectList(productService.GetProducts(), "ProductId", "Type");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContractCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateContractService();
            var productService = CreateProductService();
            var customerService = CreateCustomerService();

            customerService.GetCustomerById(model.CustomerID);
            productService.GetProductById(model.ProductId);

            ViewBag.CustomerID = new SelectList(customerService.GetCustomers(), "CustomerID", "CustomerBusinessName", model.CustomerID);
            ViewBag.ProductId = new SelectList(productService.GetProducts(), "ProductId", "ProductType", model.ProductId);

            var businessName = customerService.GetCustomerById(model.CustomerID);

            if (service.CreateContract(model))
            {
                TempData["SaveResult"] = "Your Custumer was created. ";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Product could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateContractService();
            var model = svc.GetContractById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateContractService();
            var detail = service.GetContractById(id);
            var model =
                new ContractEdit
                {
                    ContractID = detail.ContractID,
                    PaymentReceived = detail.PaymentReceived,
                    PaymentsMethod = detail.PaymentsMethod
                    
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContractEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ContractID != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateContractService();

            if (service.UpdateContract(model))
            {
                TempData["SaveResult"] = "Your contract was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your contract could not be updated.");
            return View(model);
        }

        private ContractService CreateContractService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContractService(userId);
            return service;
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }

        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }

    }
}