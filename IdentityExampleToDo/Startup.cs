using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityExampleToDo.Startup))]
namespace IdentityExampleToDo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
