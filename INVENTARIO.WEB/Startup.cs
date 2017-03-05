using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INVENTARIO.WEB.Startup))]
namespace INVENTARIO.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
