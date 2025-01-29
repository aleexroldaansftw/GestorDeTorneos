using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gestor_Torneos.Startup))]
namespace Gestor_Torneos
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
