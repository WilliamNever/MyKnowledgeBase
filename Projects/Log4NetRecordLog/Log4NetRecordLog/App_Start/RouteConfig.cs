using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Log4NetRecordLog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{id}/{action}",
                defaults: new { controller = "DoubleFormTest", action = "Index", id = "default" }// UrlParameter.Optional }
            );
        }
    }
}
