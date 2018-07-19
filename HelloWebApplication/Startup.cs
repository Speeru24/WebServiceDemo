using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloWebApplication.Startup))]
namespace HelloWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
