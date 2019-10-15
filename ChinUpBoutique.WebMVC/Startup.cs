using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChinUpBoutique.WebMVC.Startup))]
namespace ChinUpBoutique.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
