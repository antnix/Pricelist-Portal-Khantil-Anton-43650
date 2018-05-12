using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pricelist_Portal_Khantil_Anton_43650.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectCategory()
        {
            ViewBag.Models = new List<string> { "TVs", "Headphones" };

            return View();
        }
    }
}