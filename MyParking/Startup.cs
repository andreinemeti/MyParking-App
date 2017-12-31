using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyParking.Startup))]
namespace MyParking
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
