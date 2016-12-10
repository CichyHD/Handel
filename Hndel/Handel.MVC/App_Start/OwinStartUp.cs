using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Handel.DataAccess.Impl.UserManagers;
using Handel.DataAccess.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(OwinStartUp.Startup))]
namespace OwinStartUp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser, Guid>(
                     validateInterval: TimeSpan.FromMinutes(30),
                     regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                     getUserIdCallback: (user) => Guid.Parse(user.GetUserId()))
                }
            });


        }
    }
}