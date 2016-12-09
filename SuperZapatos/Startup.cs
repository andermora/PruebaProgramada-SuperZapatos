using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperZapatos.Startup))]
namespace SuperZapatos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
