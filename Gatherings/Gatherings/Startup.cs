using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gatherings.Startup))]
namespace Gatherings
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
