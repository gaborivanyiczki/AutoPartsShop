using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CarPartsStore__License_App_.Startup))]
namespace CarPartsStore__License_App_
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
