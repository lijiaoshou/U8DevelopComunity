using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace U8DevelopComunity.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult U8ProfessionalDeveloper()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult U8StudentArchives()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}