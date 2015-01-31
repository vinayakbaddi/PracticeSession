using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeSession.Controllers
{
    public class CustomURLRoutingController : Controller
    {
        // GET: CustomURLRouting
        public ActionResult HandleResults()
        {
            return View();
        }

        public ActionResult Index()
        {
            return Content("TEST");
        }
    }
}