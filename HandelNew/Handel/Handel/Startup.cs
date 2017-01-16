using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Handel.Startup))]
namespace Handel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
