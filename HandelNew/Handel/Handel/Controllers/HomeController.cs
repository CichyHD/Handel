using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Handel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowShirtsForMe()
        {
            var context = new Context();

            context.Shirt.Add(new ShirtModel()
            {
                Arms = 22,
                Chest = 11,
                Collar = 5,
                Color = "black",
                ColorType = "multi",
                Cuff = 16,
                Made = "Cropp",
                Price = 123,
                Sex = "Male",
                ShirtLength = 126,
                Sleeve = 65,
                Waist = 55
            });

            context.SaveChanges();

            return View();
        }
    }
}