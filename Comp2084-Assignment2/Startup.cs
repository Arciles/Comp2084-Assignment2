using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Comp2084_Assignment2.Startup))]
namespace Comp2084_Assignment2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
