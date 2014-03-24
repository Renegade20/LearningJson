using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LOLChampions.Startup))]
namespace LOLChampions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
