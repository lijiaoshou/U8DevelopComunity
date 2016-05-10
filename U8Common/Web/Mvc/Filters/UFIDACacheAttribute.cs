using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;
using System.Web.Mvc;

namespace UFIDA.Framework.Web.Mvc.Filters
{
    /// <summary>
    /// 缓存Action执行结果
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class UFIDACacheAttribute : ActionFilterAttribute, IActionFilter
    {
        private string CacheKey = "";
        /// <summary>
        /// 缓存时间（秒）
        /// </summary>
        public int Duration = 0;
        private CacheItemPriority Priority = CacheItemPriority.Default;
        private CacheDependency Dependency = null;
        /// <summary>
        /// Action执行前
        /// </summary>
        /// <param name="filterContext">上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string url = filterContext.HttpContext.Request.Url.PathAndQuery;
            this.CacheKey = "ResultCache-" + url;
            if (filterContext.HttpContext.Cache[this.CacheKey] != null)
            {
                filterContext.Result = (ActionResult)filterContext.HttpContext.Cache[this.CacheKey];
            }
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Action执行后
        /// </summary>
        /// <param name="filterContext">上下文</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Exception != null)
            {
                filterContext.HttpContext.Cache.Add(this.CacheKey, filterContext.Result, Dependency, DateTime.Now.AddSeconds(Duration),
                System.Web.Caching.Cache.NoSlidingExpiration, Priority, null);
            }
            base.OnActionExecuted(filterContext);
        }
    }
}
