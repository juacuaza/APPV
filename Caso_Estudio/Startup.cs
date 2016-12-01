using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Caso_Estudio.Startup))]
namespace Caso_Estudio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
