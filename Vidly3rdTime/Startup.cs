using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidly3rdTime.Startup))]
namespace Vidly3rdTime
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
