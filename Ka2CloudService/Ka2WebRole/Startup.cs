using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Ka2WebRole.Startup))]
namespace Ka2WebRole
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
