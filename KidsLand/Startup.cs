using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KidsLand.Startup))]
namespace KidsLand
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
