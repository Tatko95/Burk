using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Burk.WebUI.Startup))]
namespace Burk.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
