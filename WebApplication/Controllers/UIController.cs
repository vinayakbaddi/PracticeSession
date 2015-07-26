using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class UIController : Controller
    {
        // GET: UI
        public ActionResult BootStrapListItem()
        {
            UIModel uIModel = new UIModel();
            uIModel.DropDownItems = new List<SelectListItem>(){
                new SelectListItem(){ Text = "One", Value = "1"},
                new SelectListItem(){ Text = "Two", Value = "2"}
            };

            return View(uIModel);
        }


    }

    public class UIModel
    {
        public List<int> DataItems { get; set; }

        public List<SelectListItem> DropDownItems { get; set; }
    }
}