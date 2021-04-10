using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyPhongKham3.Startup))]
namespace QuanLyPhongKham3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
