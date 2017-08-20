using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevAssign.Filters
{
    public class HttpExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                if (filterContext.Exception is HttpRequestValidationException)
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
               new { action = "Unexpected", controller = "Error" }));
                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.ExceptionHandled = true;
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
               new { action = "HttpException", controller = "Error" }));
                    filterContext.HttpContext.Response.StatusCode = 500;
                    filterContext.ExceptionHandled = true;
                }

                DevAssign.Business.Logging.LoggingManager.GetLogger().Log(filterContext.Exception);
            }
        }
    }
}