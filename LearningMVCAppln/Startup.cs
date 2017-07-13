using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningMVCAppln.Startup))]
namespace LearningMVCAppln
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
