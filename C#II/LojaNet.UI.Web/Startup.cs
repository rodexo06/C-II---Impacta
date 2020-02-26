using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(LojaNet.UI.Web.Startup))]

namespace LojaNet.UI.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(
                new CookieAuthenticationOptions
                {
                    // Esse tipo de autentificação é um cookie que vale pela aplicação toda
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    //Para onde vai ser redirecionado caso de bosta
                    LoginPath = new PathString("/Usuario/Login")
                }
             );
            // Para obter mais informações sobre como configurar seu aplicativo, visite https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
