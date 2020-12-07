using System.Web.Mvc;

namespace SwaggerTest.Areas.AreaSubA
{
    public class AreaSubAAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaSubA";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaSubA_default",
                "AreaSubA/{controller}/{action}/{id}",
                new { controller = "HomeAreaSub", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}