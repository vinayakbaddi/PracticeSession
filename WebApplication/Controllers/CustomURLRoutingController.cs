using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class CustomURLRoutingController : Controller
    {
        // GET: CustomURLRouting
        public ActionResult HandleResults()
        {
            return View();
        }

        public ActionResult Array(int id)
        {
            return Content("Int parameter");
        }
        public ActionResult Array(string[] id)
        {
            return Content("Array");
        }

        public ActionResult Index()
        {
            return Content("TEST");
        }

        public ActionResult HandleAspxResults() {
            return Content("handling ASPX");
        }
    }
}