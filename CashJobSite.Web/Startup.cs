using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CashJobSite.Web.Startup))]
namespace CashJobSite.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
