using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Handel.DataAccess.Contract.Misc;

namespace Handel.MVC.Controllers
{
    public class BaseController : Controller
    {
        public string CurrentUser
        {
            get { return HttpContext.User.Identity.Name; }
        }

        protected void AddErrors(IIdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}