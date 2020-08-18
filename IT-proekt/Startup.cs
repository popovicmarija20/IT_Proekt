using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IT_proekt.Startup))]
namespace IT_proekt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
