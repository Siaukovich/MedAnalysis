using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MedAnalysis.Web.Startup))]
namespace MedAnalysis.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
