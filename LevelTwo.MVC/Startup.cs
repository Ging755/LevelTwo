using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LevelTwo.MVC.Startup))]
namespace LevelTwo.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
