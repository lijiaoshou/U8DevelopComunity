using System.Web.Mvc;

namespace U8.Framework.Web.Mvc
{
    /// <summary>
    /// 错误处理
    /// </summary>
    public class U8HandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 重写OnException
        /// </summary>
        /// <param name="filterContext">上下文</param>
        public override void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            filterContext.HttpContext.Response.StatusCode = 200;
        }
    }
}
