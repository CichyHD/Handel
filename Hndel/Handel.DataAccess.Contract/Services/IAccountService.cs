using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.DataAccess.Contract.Models;

namespace Handel.DataAccess.Contract
{
    public interface IAccountService
    {
        AccountServiceResult SetFirstPassword(RegisterViewModel registerModel);
        Task<LoginResult> LoginAsync(LoginViewModel loginModel);
        void SendRecoveryEmail(SendEmailViewModel passModel, string pathToPasswordRecoveryAction);
        RecoverPasswordResult RecoverPassword(RecoverPasswordViewModel recoveryModel);
        bool ResetPassword(Guid userId, string pathToSetNewPasswordAction);
        bool ResetPasswordByUser(ResetOldPasswordViewModel passwordModel);
    }

    public enum AccountServiceResult
    {
        GenericError = 0,
        InvalidEmailToken = 1,
        PasswordChangeFailed = 2,
        PasswordChangeSuccess = 4
    }

    public enum LoginResult
    {
        GenericError = 0,
        SignInSuccess = 1,
        SignInFailure = 2,
        InvalidUser = 4
    }

    public enum RecoverPasswordResult
    {
        GenericError = 0,
        PasswordRecoverySuccess = 1,
        PasswordRecoveryFailed = 2
    }
}
