using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CricketerApplication.Startup))]
namespace CricketerApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
