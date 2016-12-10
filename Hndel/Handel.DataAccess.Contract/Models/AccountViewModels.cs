using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handel.DataAccess.Contract.Models
{
    public class LoginViewModel
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public class SendEmailViewModel
    {
        public string Email { get; set; }
    }


    public class RegisterViewModel
    {
        public Guid UserId { get; set; }
        public string EmailConfirmationCode { get; set; }
        public string ResetPasswordCode { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RecoverPasswordViewModel
    {
        public string NewPasswordCode { get; set; }
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class ResetOldPasswordViewModel
    {
        public Guid UserId { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
