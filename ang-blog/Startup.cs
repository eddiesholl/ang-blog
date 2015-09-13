using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ang_blog.Startup))]
namespace ang_blog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
