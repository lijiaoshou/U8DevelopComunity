using U8.Framework.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace U8.Framework.Web.Mvc.Filters
{
    /// <summary>
    /// MVC的Action处理时间计算
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]
    public class U8ActionExecuteTimeAttribute : ActionFilterAttribute, IActionFilter
    {
        private Stopwatch stopwatch = new Stopwatch();
        /// <summary>
        /// 日志路径
        /// </summary>
        public string logPath = null;
        /// <summary>
        /// Action执行前
        /// </summary>
        /// <param name="filterContext">上下文</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            stopwatch.Reset();
            stopwatch.Start();
            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Action执行后
        /// </summary>
        /// <param name="filterContext">上下文</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopwatch.Stop();
            try
            {
                if (logPath != null && logPath.Length > 0)
                {
                    U8File.Write(logPath, filterContext.ActionDescriptor.ActionName + " 执行时间：" + stopwatch.ElapsedMilliseconds+"毫秒");
                }
            }
            catch
            {
            }
            finally
            {
                base.OnActionExecuted(filterContext);
            }
        }

    }
}
