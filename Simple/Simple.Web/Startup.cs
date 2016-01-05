using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Simple.Web.Startup))]
namespace Simple.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
