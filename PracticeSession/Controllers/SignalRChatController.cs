using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PracticeSession.Controllers
{
    public class SignalRChatController : Controller
    {
        public ActionResult Chat()
        {
            return View();
        }

        public ActionResult Receive()
        {
            return View();
        }
    }
}
