using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ForNodeJSTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Process1/Default",
                url: "Process1/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "ForNodeJSTest.Controllers.Process1" }
            );

            routes.MapRoute(
                            name: "Default",
                            url: "{controller}/{action}/{id}",
                            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                            namespaces: new string[] { "ForNodeJSTest.Controllers" }
                        );
        }
    }
}
