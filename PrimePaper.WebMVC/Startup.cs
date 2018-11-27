using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrimePaper.WebMVC.Startup))]
namespace PrimePaper.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
