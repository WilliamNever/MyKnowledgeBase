using NetMVCWebSite.Filters;
using System.Web;
using System.Web.Mvc;

namespace NetMVCWebSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthenticFilterAttribute());
        }
    }
}
