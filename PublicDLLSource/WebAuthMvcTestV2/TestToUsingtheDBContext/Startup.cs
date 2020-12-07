using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestToUsingtheDBContext.Startup))]
namespace TestToUsingtheDBContext
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
