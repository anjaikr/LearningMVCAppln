using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearningMVCWithCodeFirst.Startup))]
namespace LearningMVCWithCodeFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
