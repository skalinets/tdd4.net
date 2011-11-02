using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Site.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            return View();
        }


        public ActionResult Contacts()
        {
            return View();
        }
    }
}
