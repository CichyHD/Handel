using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace Handel.MVC.Infrastructure.IoC
{
    public class AuthenticationMangerFactory
    {
        public static IAuthenticationManager CreateAuthManagerStatic()
        {
            return HttpContext.Current.GetOwinContext().Authentication;
        }
    }
}