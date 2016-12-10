using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.Contracts;
using Handel.DataAccess.Contract.Enums;
using Handel.DataAccess.Contract.UserManagers;
using Handel.DataAccess.Impl.Helpers;
using Handel.DataAccess.Implementation;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Handel.DataAccess.Impl.UserManagers
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, Guid>, ISignInManager
    {
        public ApplicationSignInManager(IUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager as ApplicationUserManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(ApplicationUserManager appUserManager, IAuthenticationManager authManager)
        {
            return new ApplicationSignInManager(appUserManager, authManager);
        }

        public async Task<MySignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent)
        {
            var msresult = await (this as SignInManager<ApplicationUser, Guid>).PasswordSignInAsync(userName, password, isPersistent, false);
            return SignInStatusConverter.Convert(msresult);
        }

        public async Task SignInAsync(IApplicationUser user, bool isPersistent, bool rememberBrowser)
        {
            await (this as ApplicationSignInManager).SignInAsync(user.ConvertTo<ApplicationUser>(), isPersistent, rememberBrowser);
        }
    }
}
