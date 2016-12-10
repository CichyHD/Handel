using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.DataAccess.Contract.Enums;
using Microsoft.AspNet.Identity.Owin;

namespace Handel.DataAccess.Impl.Helpers
{
    public static class SignInStatusConverter
    {
        public static MySignInStatus Convert(SignInStatus source)
        {
            var result = (MySignInStatus)((int)source);
            return result;
        }
    }
}
