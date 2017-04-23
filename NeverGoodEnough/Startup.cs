using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeverGoodEnough.Startup))]
namespace NeverGoodEnough
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
