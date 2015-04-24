using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class FiltersController : Controller
    {
        // GET: Filters
        [OutputCache(Duration=30)]
        public ActionResult Index()
        {
            return Content(DateTime.Now.ToString());
        }
    }
}