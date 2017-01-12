using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Handel.MVC.Controllers
{
    public class ProductDetailsController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Details";

            return View();
        }
    }
}
