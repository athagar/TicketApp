using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TicketApp.Startup))]
namespace TicketApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
