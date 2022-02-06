using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RailwayReservation.Startup))]
namespace RailwayReservation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
