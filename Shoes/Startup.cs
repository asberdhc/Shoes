using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shoes.Startup))]
namespace Shoes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
