using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookLibrary.Web.Startup))]
namespace BookLibrary.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
