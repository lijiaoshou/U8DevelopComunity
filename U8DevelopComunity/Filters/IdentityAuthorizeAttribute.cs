using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U8DevelopComunity;

namespace U8DevelopComunity.Filters
{
    /// <summary>
    /// 验证特性（验证是否拥登录）
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class IdentityAuthorizeAttribute : ActionFilterAttribute, IActionFilter
    {
        public bool NoAuthorize = false;
        /// <summary>
        /// Action执行前
        /// </summary>
        /// <param name="filterContext">上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!NoAuthorize)
            {
                try
                {
                    if (!Common.Identity.IsAuthenticated)
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.Write("<script>window.top.location='" +Common.Config.LoginUrl + "'</script>");
                        HttpContext.Current.Response.End();
                        filterContext.Result = new EmptyResult();
                    }
                    //判断用户是否有统计分析的权限

                    base.OnActionExecuting(filterContext);
                }
                catch (Exception exception)
                {
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.Write(exception.Message);
                    HttpContext.Current.Response.End();
                    filterContext.Result = new EmptyResult();
                }
            }

        }
    }
}