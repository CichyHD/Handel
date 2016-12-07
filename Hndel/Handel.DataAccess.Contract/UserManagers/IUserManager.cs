using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.BusinessClasses;
using Handel.Core.Contracts;
using Handel.DataAccess.Contract.Misc;

namespace Handel.DataAccess.Contract.UserManagers
{
    public interface IUserManager<T> where T : IBaseObject, IApplicationUser
    {
        Task<IIdentityResult> CreateAsync(T user, string password);
        Task<IIdentityResult> ConfirmEmailAsync(T user, string token);
        Task<T> FindByNameAsync(T user);
        Task<bool> IsEmailConfirmedAsync(T user);
        Task<IIdentityResult> ResetPasswordAsync(T user, string token, string newPassword);
        Task<ClaimsIdentity> CreateIdentityAsync(T user, string authType);
        Task<T> FindByIdAsync(Guid id);
        T FindById(Guid key);
        Task<IIdentityResult> DeleteAsync(T user);
        Task<T> FindByEmial(string email);
        Task<T> FindByPersonAsync(T person);
        T FindByPerson(T person);
        Task<IIdentityResult> AddRoleAsync(T user, string role);
        IIdentityResult AddRole(T user, string recenzent);
        IQueryable<T> FindUsers(Expression<Func<T, bool>> query);
        IQueryable<T> GetAllUsersInRole(string roleName);
        IQueryable<T> GetAllUsers(Expression<Func<T, bool>> query);
    }
}
