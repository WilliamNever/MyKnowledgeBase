using System.Web.Mvc;

namespace SwaggerTest.Areas.AreaSecondSub
{
    public class AreaSecondSubAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AreaSecondSub";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AreaSecondSub_default",
                "AreaSecondSub/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}