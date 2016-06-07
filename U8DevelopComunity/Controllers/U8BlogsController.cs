using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U8DevelopComunity.Filters;

namespace U8DevelopComunity.Controllers
{
    [IdentityAuthorize]
    public class U8BlogsController : Controller
    {
        // GET: U8Blogs
        public ActionResult Index()
        {
            return View();
        }
    }
}