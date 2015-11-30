using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KlexTeam.Startup))]
namespace KlexTeam
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
