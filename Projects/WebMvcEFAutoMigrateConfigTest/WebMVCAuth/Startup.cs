using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVCAuth.Startup))]
namespace WebMVCAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
