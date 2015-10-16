using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MMSWebApp.Startup))]
namespace MMSWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
