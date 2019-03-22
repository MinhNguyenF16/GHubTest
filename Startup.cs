using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GHub.Startup))]
namespace GHub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
