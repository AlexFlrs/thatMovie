using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Movie.Web.Startup))]
namespace Movie.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
