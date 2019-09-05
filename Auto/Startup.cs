using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Auto.Startup))]
namespace Auto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
