using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tinyCRM.Startup))]
namespace tinyCRM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
