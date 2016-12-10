using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.Contracts;
using Handel.DataAccess.Contract.Misc;
using Handel.DataAccess.Contract.UserManagers;
using Handel.DataAccess.Impl.IdentityResult;
using Handel.DataAccess.Impl.Services;
using Handel.DataAccess.Implementation;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Handel.DataAccess.Impl.UserManagers
{
    public class ApplicationUserManager : UserManager<ApplicationUser, Guid>, IUserManager
    {
        private readonly DbContext _dbContext;
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser, Guid> _manager;
        private readonly IdentityFactoryOptions<ApplicationUserManager> _options;
        private readonly RoleManager<GuidRole, Guid> _roleManager;

        public ApplicationUserManager(DbContext dbContext, RoleManager<GuidRole, Guid> roleManager,
            IdentityFactoryOptions<ApplicationUserManager> options, IEmailService emailService) :
                base(
                new UserStore<ApplicationUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>(dbContext))
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _options = options;
            _emailService = emailService;
            _manager = this;
            ConfigureManager(this, emailService);
        }

        public IIdentityResult AddRole(IApplicationUser user, string role)
        {
            if (_manager.IsInRole(user.Id, role))
            {
                return
                    new MyIdentityResult(new Microsoft.AspNet.Identity.IdentityResult($"User is already in role {role}"));
            }

            var result = _manager.AddToRole(user.Id, role);
            var myResult = new MyIdentityResult(result);
            return myResult;
        }

        IIdentityResult IUserManager.ResetPassword(IApplicationUser user, string resetPasswordCode, string password)
        {
            throw new NotImplementedException();
        }

        public IIdentityResult ChangePasswordWithoutToken(IApplicationUser user, string newPassword)
        {
            var passwordHash = _manager.PasswordHasher.HashPassword(newPassword);
            var appUser = user.ConvertTo<ApplicationUser>();
            appUser.PasswordHash = passwordHash;
            var result = _manager.Update(appUser);
            return new MyIdentityResult(result);
        }

        public IIdentityResult AddToRoles(IApplicationUser user, string[] roles)
        {
            var result = _manager.AddToRoles(user.Id, roles);
            return new MyIdentityResult(result);
        }

        public IIdentityResult RemoveFromRoles(IApplicationUser user, string[] roles)
        {
            var result = _manager.RemoveFromRoles(user.Id, roles);
            return new MyIdentityResult(result);
        }

        public IApplicationUser FindByPerson(IApplicationUser person)
        {
            throw new NotImplementedException();
        }

        public async Task<IIdentityResult> AddRoleAsync(IApplicationUser user, string role)
        {
            if (_manager.IsInRole(user.Id, role))
            {
                return
                    new MyIdentityResult(new Microsoft.AspNet.Identity.IdentityResult($"User is already in role {role}"));
            }
            return new MyIdentityResult(await _manager.AddToRoleAsync(user.Id, role));
        }

        public async Task<IIdentityResult> ConfirmEmailAsync(IApplicationUser user, string token)
        {
            var baseIdent = await _manager.ConfirmEmailAsync(user.Id, token);
            return new MyIdentityResult(baseIdent);
        }

        public Task<IApplicationUser> FindByNameAsync(IApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public IIdentityResult ConfirmEmail(IApplicationUser user, string token)
        {
            var baseIdent = _manager.ConfirmEmail(user.Id, token);
            return new MyIdentityResult(baseIdent);
        }

        public async Task<IIdentityResult> CreateAsync(IApplicationUser user, string password)
        {
            var identUser = user.ConvertTo<ApplicationUser>();
            return new MyIdentityResult(await _manager.CreateAsync(identUser, password));
        }

        public IIdentityResult Create(IApplicationUser user, string password)
        {
            var identUser = user.ConvertTo<ApplicationUser>();
            return new MyIdentityResult(_manager.Create(identUser, password));
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(IApplicationUser user, string authType)
        {
            var identUser = user.ConvertTo<ApplicationUser>();
            return await _manager.CreateIdentityAsync(identUser, authType);
        }

        public async Task<IIdentityResult> DeleteAsync(IApplicationUser user)
        {
            return new MyIdentityResult(await _manager.DeleteAsync(user.ConvertTo<ApplicationUser>()));
        }

        IApplicationUser IUserManager.FindByEmial(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IApplicationUser> FindByPersonAsync(IApplicationUser person)
        {
            throw new NotImplementedException();
        }

        public async Task<IApplicationUser> FindByEmialAsync(string email)
        {
            return await _manager.FindByEmailAsync(email);
        }

        public IApplicationUser FindByEmial(string email)
        {
            return _manager.FindByEmail(email);
        }

        public IApplicationUser FindById(Guid key)
        {
            return _manager.FindById(key);
        }

        public new async Task<IApplicationUser> FindByIdAsync(Guid id)
        {
            var user = await _manager.FindByIdAsync(id);
            return user;
        }

        public new async Task<IApplicationUser> FindByNameAsync(string userName)
        {
            return await _manager.FindByNameAsync(userName);
        }

        public IQueryable<IApplicationUser> FindUsers(Expression<Func<IApplicationUser, bool>> query)
        {
            var users = _manager.Users.AsNoTracking().Where(query).AsNoTracking();
            return users;
        }

        public IQueryable<IApplicationUser> GetAllUsersInRole(string roleName)
        {
            var roleId = _roleManager.FindByName(roleName).Id;

            var users = Users.AsNoTracking().Where(x => x.Roles.Select(y => y.RoleId).Contains(roleId));
            return users;
        }

        public IQueryable<IApplicationUser> GetAllUsers(Expression<Func<IApplicationUser, bool>> query)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsEmailConfirmedAsync(IApplicationUser user)
        {
            return await _manager.IsEmailConfirmedAsync(user.Id);
        }

        public bool IsEmailConfirmed(IApplicationUser user)
        {
            return _manager.IsEmailConfirmed(user.Id);
        }

        public bool IsEmailConfirmed(Guid userId)
        {
            return _manager.IsEmailConfirmed(userId);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(IApplicationUser user)
        {
            return await _manager.GeneratePasswordResetTokenAsync(user.Id);
        }

        public string GeneratePasswordResetToken(IApplicationUser user)
        {
            return _manager.GeneratePasswordResetToken(user.Id);
        }

        public void SendEmail(IApplicationUser user, object subject, object body)
        {
            throw new NotImplementedException();
        }

        public async Task<IIdentityResult> ResetPasswordAsync(IApplicationUser user, string token, string newPassword)
        {
            return new MyIdentityResult(await _manager.ResetPasswordAsync(user.Id, token, newPassword));
        }

        public IIdentityResult ResetPassword(IApplicationUser user, string token, string newPassword)
        {
            return new MyIdentityResult(_manager.ResetPassword(user.Id, token, newPassword));
        }

        public IIdentityResult ChangePassword(Guid userId, string oldPassword, string newPassword)
        {
            return new MyIdentityResult(_manager.ChangePassword(userId, oldPassword, newPassword));
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(IApplicationUser user)
        {
            return await _manager.GenerateEmailConfirmationTokenAsync(user.Id);
        }

        public string GenerateEmailConfirmationToken(IApplicationUser user)
        {
            return _manager.GenerateEmailConfirmationToken(user.Id);
        }

        public async Task SendEmailAsync(IApplicationUser user, string subject, string body)
        {
            await _manager.SendEmailAsync(user.Id, subject, body);
        }

        public void SendEmail(IApplicationUser user, string subject, string body)
        {
            _manager.SendEmail(user.Id, subject, body);
        }

        public new async Task<IIdentityResult> ConfirmEmailAsync(Guid userId, string token)
        {
            var baseIdent = await _manager.ConfirmEmailAsync(userId, token);
            return new MyIdentityResult(baseIdent);
        }

        public IIdentityResult ConfirmEmail(Guid userId, string token)
        {
            var baseIdent = _manager.ConfirmEmail(userId, token);
            return new MyIdentityResult(baseIdent);
        }

        public bool IsInRole(IApplicationUser user, string roleName)
        {
            return _manager.IsInRole(user.Id, roleName);
        }

        public IEnumerable<string> GetAllUserRoles(IApplicationUser user)
        {
            var roles = _manager.GetRoles(user.Id);
            return roles;
        }

        public IIdentityResult UpdateUser(IApplicationUser user)
        {
            var result = _manager.Update(user.ConvertTo<ApplicationUser>());
            return new MyIdentityResult(result);
        }

        public bool CheckUserPassword(Guid userId, string password)
        {
            var user = new ApplicationUser
            {
                Id = userId
            };
            var result = _manager.CheckPassword(user, password);
            return result;
        }

        public int UsersCount()
        {
            return _manager.Users.Count();
        }

        public IIdentityResult RemoveFromRole(IApplicationUser user, string role)
        {
            if (!_manager.IsInRole(user.Id, role))
            {
                return new MyIdentityResult(new Microsoft.AspNet.Identity.IdentityResult($"User is not in role {role}"));
            }
            var result = _manager.RemoveFromRole(user.Id, role);
            var myResult = new MyIdentityResult(result);
            return myResult;
        }

        public void ConfigureManager(ApplicationUserManager manager, IEmailService emailService)
        {
            manager.UserValidator = new UserValidator<ApplicationUser, Guid>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false
            };


            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 50;
            if (_options != null)
            {
                manager.EmailService = new IdentityEmailService(emailService);

                var dataProtectionProvider = _options.DataProtectionProvider;
                if (dataProtectionProvider != null)
                {
                    manager.UserTokenProvider =
                        new DataProtectorTokenProvider<ApplicationUser, Guid>(
                            dataProtectionProvider.Create("ASP.NET Identity"))
                        {TokenLifespan = TimeSpan.FromDays(1)};
                }
            }
        }
    }
}
