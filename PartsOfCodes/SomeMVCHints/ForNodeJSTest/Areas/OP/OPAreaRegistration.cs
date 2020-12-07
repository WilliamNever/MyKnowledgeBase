using System.Web.Mvc;

namespace ForNodeJSTest.Areas.OP
{
    public class OPAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "OP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "OP_default",
                "OP/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home", id = UrlParameter.Optional }
            );
        }
    }
}