using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fenergo.Ui.Startup))]
namespace Fenergo.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
