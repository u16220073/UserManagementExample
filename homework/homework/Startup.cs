using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(homework.Startup))]
namespace homework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
