using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mbensaeed.Startup))]
namespace mbensaeed
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
