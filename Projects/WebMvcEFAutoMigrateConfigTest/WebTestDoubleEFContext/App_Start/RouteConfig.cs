using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTestDoubleEFContext
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "UserInfors",
                url: "us/{action}/{id}",
                defaults: new { controller = "UserInfors", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "OrdersInfors",
                url: "odif/{action}/{id}",
                defaults: new { controller = "OrdersInfors", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
