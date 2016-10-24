using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParkingLotWebApp.Startup))]
namespace ParkingLotWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
