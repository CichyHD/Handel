using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Handel.DataAccess.Contract;
using Handel.DataAccess.Contract.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Handel.MVC.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IAccountService _accountService;

        public AccountController(IAuthenticationManager authenticationManager, IAccountService accountService)
        {
            _authenticationManager = authenticationManager;
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult SetFirstPassword(Guid UserId, string emailConfirmationCode, string resetPasswordCode)
        {
            var model = new RegisterViewModel();
            model.UserId = UserId;
            model.EmailConfirmationCode = emailConfirmationCode;
            model.ResetPasswordCode = resetPasswordCode;
            return View(model);
        }

        [HttpPost]
        public ActionResult SetFirstPassword(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _accountService.SetFirstPassword(model);
            switch (result)
            {
                case AccountServiceResult.InvalidEmailToken:
                    ViewBag.errorMessage = "";//todoMain.InvalidEmailToken;
                    return View("Error");
                case AccountServiceResult.PasswordChangeFailed:
                    ViewBag.errorMessage = "";//todoMain.ResetPasswordFailed;
                    return View("Error");
                case AccountServiceResult.PasswordChangeSuccess:
                    return RedirectToAction("Index", "Home");
                default:
                    ViewBag.errorMessage = "";//todoMain.EmailConfirmationFailed;
                    return View("Error");
            }
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await _accountService.LoginAsync(model);
            switch (result)
            {
                case LoginResult.SignInSuccess:
                    return RedirectToLocal(returnUrl);
                case LoginResult.InvalidUser:
                    return View("LoginError");
                case LoginResult.SignInFailure:
                case LoginResult.GenericError:
                    ModelState.AddModelError("", "");//todoMain.LoginInvalidloginattempt);
                    goto default;
                default:
                    return View(model);
            }
        }

        [HttpGet]
        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(SendEmailViewModel model)
        {
            _accountService.SendRecoveryEmail(model, Url.Action("RecoveryPassword", "Account", null, this.Request.Url.Scheme));
            return View("RecoveryEmailSend");
        }

        [HttpGet]
        public ActionResult LogOff()
        {
            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult RecoveryPassword(Guid UserId, string passCode)
        {
            var model = new RecoverPasswordViewModel();
            model.UserId = UserId;
            model.NewPasswordCode = passCode;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecoveryPassword(RecoverPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = _accountService.RecoverPassword(model);

            switch (result)
            {
                case RecoverPasswordResult.PasswordRecoverySuccess:
                    return View("PasswordChangeSuccess");

                case RecoverPasswordResult.GenericError:
                case RecoverPasswordResult.PasswordRecoveryFailed:
                default:
                    return View("PasswordChangeFailed");
            }
        }

    }
}