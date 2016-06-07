using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace U8DevelopComunity.Filters
{
    public class AdminActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Common.Identity identity =Common.Identity.User;
            var hasLimit =Common.PermissionHelper.HasAdminLimit(identity.UserId);
            if (!hasLimit)
            {
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Write("<script>alert('你没有权限查看该页面,将跳转回U8社区主页！');setTimeout(function(){location.href='/U8System/Index';},1000)</script>");//("/NotFound/Temp.do", true);
                HttpContext.Current.Response.End();
                filterContext.Result = new EmptyResult();
            }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}