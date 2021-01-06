using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StadiumManagement.Startup))]
namespace StadiumManagement
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
