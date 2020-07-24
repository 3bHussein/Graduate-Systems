using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gnew.Startup))]
namespace Gnew
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
