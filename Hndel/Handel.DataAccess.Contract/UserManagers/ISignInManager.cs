using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.Contracts;
using Handel.DataAccess.Contract.Enums;

namespace Handel.DataAccess.Contract.UserManagers
{
    public interface ISignInManager<T> where T : IApplicationUser
    {
        Task<SignInStatus> PasswordSignInAsync(string userName, string password, bool isPersistent);
        Task SignInAsync(T user, bool isPersistent, bool rememberBrowser);
    }
}
