using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningMVCWithEF.Startup))]
namespace LearningMVCWithEF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
