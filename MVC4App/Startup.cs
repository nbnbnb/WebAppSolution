using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC4App.Startup))]
namespace MVC4App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
