using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.Contracts;
using Handel.DataAccess.Contract.Enums;

namespace Handel.DataAccess.Contract.UserManagers
{
    public interface ISignInManager
    {
        Task<MySignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent);
        Task SignInAsync(IApplicationUser user, bool isPersistent, bool rememberBrowser);
    }
}
