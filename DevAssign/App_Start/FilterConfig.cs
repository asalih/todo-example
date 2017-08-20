using DevAssign.Filters;
using System.Web;
using System.Web.Mvc;

namespace DevAssign
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HttpExceptionFilter());

        }
    }
}
