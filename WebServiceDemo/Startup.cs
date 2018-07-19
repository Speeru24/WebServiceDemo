using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebServiceDemo.Startup))]
namespace WebServiceDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
