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
    public interface IUserManager
    {
        Task<IIdentityResult> CreateAsync(IApplicationUser user, string password);
        Task<IIdentityResult> ConfirmEmailAsync(IApplicationUser user, string token);
        Task<IApplicationUser> FindByNameAsync(IApplicationUser user);
        Task<bool> IsEmailConfirmedAsync(IApplicationUser user);
        Task<IIdentityResult> ResetPasswordAsync(IApplicationUser user, string token, string newPassword);
        Task<ClaimsIdentity> CreateIdentityAsync(IApplicationUser user, string authType);
        Task<IApplicationUser> FindByIdAsync(Guid id);
        IApplicationUser FindById(Guid key);
        Task<IIdentityResult> DeleteAsync(IApplicationUser user);
        IApplicationUser FindByEmial(string email);
        Task<IApplicationUser> FindByPersonAsync(IApplicationUser person);
        IApplicationUser FindByPerson(IApplicationUser person);
        Task<IIdentityResult> AddRoleAsync(IApplicationUser user, string role);
        IIdentityResult AddRole(IApplicationUser user, string recenzent);
        IQueryable<IApplicationUser> FindUsers(Expression<Func<IApplicationUser, bool>> query);
        IQueryable<IApplicationUser> GetAllUsersInRole(string roleName);
        IQueryable<IApplicationUser> GetAllUsers(Expression<Func<IApplicationUser, bool>> query);
        IIdentityResult ChangePassword(Guid userId, string oldPassword, string confirmPassword);
        Task<IApplicationUser> FindByEmialAsync(string email);
        bool IsEmailConfirmed(Guid userId);
        IIdentityResult ConfirmEmail(Guid userId, string emailConfirmationCode);
        IIdentityResult ResetPassword(IApplicationUser user, string resetPasswordCode, string password);
        IIdentityResult ChangePasswordWithoutToken(IApplicationUser user, string toString);
        string GeneratePasswordResetToken(IApplicationUser user);
        void SendEmail(IApplicationUser user, object subject, object body);
    }
}
