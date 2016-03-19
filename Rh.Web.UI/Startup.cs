using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rh.Web.UI.Startup))]
namespace Rh.Web.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
