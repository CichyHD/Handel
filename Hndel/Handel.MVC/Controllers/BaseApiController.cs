using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Handel.MVC.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        public string CurrentUser
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
    }
}