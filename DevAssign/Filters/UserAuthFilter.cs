using DevAssign.Business;
using DevAssign.Data.Model;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevAssign.Filters
{
    public class UserAuthFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = filterContext.HttpContext.Session[Consts.SESSION_USER_KEY] as User;
            if(user == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
               new { action = "Login", controller = "Common" }));
            }
        }
    }
}