using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comp2084_Assignment2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This application designed to keep track of your auction items. Calculate your profit from auctioned items and more.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "For further questions plase contact Esat IBIS.";

            return View();
        }
    }
}