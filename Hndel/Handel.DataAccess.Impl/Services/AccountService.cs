using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using Handel.Core.Contracts;
using Handel.DataAccess.Contract;
using Handel.DataAccess.Contract.Enums;
using Handel.DataAccess.Contract.Misc;
using Handel.DataAccess.Contract.Models;
using Handel.DataAccess.Contract.UserManagers;
using Microsoft.AspNet.Identity.Owin;

namespace Handel.DataAccess.Impl.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserManager _userManager;
        private readonly ISignInManager _signInManager;

        public AccountService(IUserManager userManager, ISignInManager singInManager)
        {
            _userManager = userManager;
            _signInManager = singInManager;
        }

        public async Task<LoginResult> LoginAsync(LoginViewModel loginModel)
        {

            var user = await _userManager.FindByEmialAsync(loginModel.Email);
            if (user != null && !user.EmailConfirmed)
            {

                return LoginResult.InvalidUser;
            }
            var result = await _signInManager.PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe);
            switch (result)
            {
                case MySignInStatus.Success:
                    return LoginResult.SignInSuccess;
                case MySignInStatus.Failure:
                default:
                    return LoginResult.SignInFailure;
            }
        }


        public AccountServiceResult SetFirstPassword(RegisterViewModel registerModel)
        {

            IIdentityResult emailResult = null;
            bool isEmailAlreadyConfirmed;
            try
            {
                isEmailAlreadyConfirmed = _userManager.IsEmailConfirmed(registerModel.UserId);
                if (!isEmailAlreadyConfirmed)
                {
                    emailResult = _userManager.ConfirmEmail(registerModel.UserId, registerModel.EmailConfirmationCode);
                }
            }
            catch (InvalidOperationException ioe)
            {
                return AccountServiceResult.InvalidEmailToken;
            }

            if ((emailResult != null && emailResult.Succeeded) || isEmailAlreadyConfirmed)
            {
                var user = _userManager.FindById(registerModel.UserId);
                var changePassResult = _userManager.ResetPassword(user, registerModel.ResetPasswordCode, registerModel.Password);
                if (changePassResult.Succeeded)
                {
                    return AccountServiceResult.PasswordChangeSuccess;
                }
                else
                {
                    return AccountServiceResult.PasswordChangeFailed;
                }
            }
            return AccountServiceResult.GenericError;


        }

        public void SendRecoveryEmail(SendEmailViewModel passModel, string pathToSetNewPasswordAction)
        {
            var user = _userManager.FindByEmial(passModel.Email);
            if (user != null)
            {
                SendResetPasswordEmail(user, pathToSetNewPasswordAction);
            }
        }


        public RecoverPasswordResult RecoverPassword(RecoverPasswordViewModel recoveryModel)
        {

            var user = _userManager.FindById(recoveryModel.UserId);
            if (user != null)
            {
                var resetResult = _userManager.ResetPassword(user, recoveryModel.NewPasswordCode, recoveryModel.Password);
                if (resetResult.Succeeded)
                {
                    return RecoverPasswordResult.PasswordRecoverySuccess;
                }
                else
                {
                    return RecoverPasswordResult.PasswordRecoveryFailed;
                }
            }
            return RecoverPasswordResult.GenericError;

        }

        public bool ResetPassword(Guid userId, string pathToSetNewPasswordAction)
        {

            var user = _userManager.FindById(userId);
            if (user == null)
            {
                return false;
            }
            else
            {
                _userManager.ChangePasswordWithoutToken(user, Guid.NewGuid().ToString());
                SendResetPasswordEmail(user, pathToSetNewPasswordAction);
                return true;
            }

        }

        public bool ResetPasswordByUser(ResetOldPasswordViewModel passwordModel)
        {

            var result = _userManager.ChangePassword(passwordModel.UserId, passwordModel.OldPassword,
                passwordModel.ConfirmPassword);
            return result.Succeeded;

        }

        private void SendResetPasswordEmail(IApplicationUser user, string pathToSetNewPasswordAction)
        {
            var passCode = HttpUtility.UrlEncode(_userManager.GeneratePasswordResetToken(user));
            var callbackLink = $"{pathToSetNewPasswordAction}?UserId={user.Id}&passCode={passCode}";

            var subject = "";//todoResources.Main.RecoveryPasswordSubject;
            var body = string.Format(""/*todoResources.Main.RecoveryPasswordBody*/, callbackLink);

            _userManager.SendEmail(user, subject, body);

        }
    }
}
