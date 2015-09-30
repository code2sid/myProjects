using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDapper.Startup))]
namespace MVCDapper
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
