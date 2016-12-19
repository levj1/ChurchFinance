using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChurchFinanceSite.Startup))]
namespace ChurchFinanceSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
