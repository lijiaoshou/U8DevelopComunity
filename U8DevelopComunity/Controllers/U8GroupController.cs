using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U8DevelopComunity.Filters;

namespace U8DevelopComunity.Controllers
{
    [IdentityAuthorize]
    public class U8GroupController : Controller
    {
        // GET: U8Group
        public ActionResult Index()
        {
            return View();
        }
    }
}