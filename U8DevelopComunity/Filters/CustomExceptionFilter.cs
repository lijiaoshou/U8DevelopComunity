using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace U8DevelopComunity.Filters
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CustomExceptionFilter : HandleErrorAttribute, IExceptionFilter
    {
        public string actionName;
        public int level = 3;
        public int isCustomerErrorMessage = 0;
        public override void OnException(ExceptionContext filterContext)
        {
            object controllerName;
            object _actionName;
            filterContext.RequestContext.RouteData.Values.TryGetValue("Controller", out controllerName);
            filterContext.RequestContext.RouteData.Values.TryGetValue("Action", out _actionName);
            if (controllerName != null && controllerName.ToString().ToLower() != "error")
            {
                bool isPart = filterContext.IsChildAction;

                string name = actionName;
                int _level = level;
                int _isCustomerErrorMessage = isCustomerErrorMessage;
                var routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                routeData.Values.Add("action", "Index");
                routeData.Values.Add("httpException", filterContext.Exception);
                routeData.Values.Add("_logTitle", string.IsNullOrEmpty(name) ? "/" + controllerName + "/" + _actionName + ".do" : name);
                routeData.Values.Add("_logLevel", _level);
                routeData.Values.Add("_isCustomerErrorMessage", _isCustomerErrorMessage);
                routeData.Values.Add("_controllerName", controllerName);
                routeData.Values.Add("isPart", isPart);
                var errorController = ControllerBuilder.Current.GetControllerFactory().CreateController(
                    new RequestContext(filterContext.HttpContext, routeData), "Error");
                errorController.Execute(new RequestContext(filterContext.HttpContext, routeData));
                filterContext.Result = new EmptyResult();

            }

            //base.OnException(filterContext);
        }
    }
}