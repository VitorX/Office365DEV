using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebHooks.Startup))]
namespace WebHooks
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
