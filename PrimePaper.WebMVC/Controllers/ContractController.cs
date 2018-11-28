using PrimePaper.Models;
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
            var model = new ContractListItem[0];
            return View(model);
        }
    }
}