using DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Handel.Models;
using Microsoft.Owin.Security;
using DB;

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

        public ActionResult UpdateDatabase()
        {
            var context = new Context();
            context.Shirt.ToList().RemoveAll(x => 1 == 1);
            context.SaveChanges();

            SaveXml("https://sklep-sggw-3.herokuapp.com/shared/db.xml");
            SaveXml("https://sklep-sggw-2.herokuapp.com/shared/db.xml");
            SaveXml("https://sklep-sggw.herokuapp.com/shared/db.xml");

            return View();
        }

        public ActionResult ShowShirtsForMe()
        {
            var context = new Context();

            string currentUserName = User.Identity.GetUserName();

            UserPreferences userPreferences = context.UserPreferences.Where(x => x.UserId == currentUserName).FirstOrDefault();

            var modeldb = context.Shirt.Where(x =>
                userPreferences.Arms - 1 <= x.Arms && x.Arms <= userPreferences.Arms + 2
                &&
                userPreferences.Chest <= x.Chest && x.Chest <= userPreferences.Chest + 2
                &&
                userPreferences.Collar <= x.Collar && x.Collar <= userPreferences.Collar + 1
                &&
                userPreferences.Color == x.Color
                &&
                userPreferences.Cuff <= x.Cuff && x.Cuff <= userPreferences.Cuff + 1
                &&
                userPreferences.Made.ToLower() == x.Made.ToLower()
                &&
                userPreferences.Price >= x.Price
                &&
                userPreferences.Sex.ToLower() == x.Sex.ToLower()
                &&
                userPreferences.ShirtLength + 3 >= x.ShirtLength && userPreferences.ShirtLength - 1 <= x.ShirtLength
                &&
                userPreferences.Sleeve + 2 >= x.Sleeve && userPreferences.Sleeve - 1 <= x.Sleeve
                &&
                userPreferences.Waist + 2 >= x.Waist && userPreferences.Waist - 1 <= x.Waist
            ).ToList();

            if (modeldb.Count < 5)
            {
                    modeldb = context.Shirt.Where(x =>
                    userPreferences.Arms - 1 <= x.Arms && x.Arms <= userPreferences.Arms + 2
                    &&
                    userPreferences.Chest <= x.Chest && x.Chest <= userPreferences.Chest + 2
                    &&
                    userPreferences.Collar <= x.Collar && x.Collar <= userPreferences.Collar + 1
                    &&
                    userPreferences.Cuff <= x.Cuff && x.Cuff <= userPreferences.Cuff + 1
                    &&
                    userPreferences.Made.ToLower() == x.Made.ToLower()
                    &&
                    userPreferences.Price >= x.Price
                    &&
                    userPreferences.Sex.ToLower() == x.Sex.ToLower()
                    &&
                    userPreferences.ShirtLength + 3 >= x.ShirtLength && userPreferences.ShirtLength - 1 <= x.ShirtLength
                    &&
                    userPreferences.Sleeve + 2 >= x.Sleeve && userPreferences.Sleeve - 1 <= x.Sleeve
                    &&
                    userPreferences.Waist + 2 >= x.Waist && userPreferences.Waist - 1 <= x.Waist
                ).ToList();
            }

            if (modeldb.Count < 5)
            {
                modeldb = context.Shirt.Where(x =>
                userPreferences.Arms - 1 <= x.Arms && x.Arms <= userPreferences.Arms + 2
                &&
                userPreferences.Chest <= x.Chest && x.Chest <= userPreferences.Chest + 2
                &&
                userPreferences.Collar <= x.Collar && x.Collar <= userPreferences.Collar + 1
                &&
                userPreferences.Cuff <= x.Cuff && x.Cuff <= userPreferences.Cuff + 1
                &&
                userPreferences.Price >= x.Price
                &&
                userPreferences.Sex.ToLower() == x.Sex.ToLower()
                &&
                userPreferences.ShirtLength + 3 >= x.ShirtLength && userPreferences.ShirtLength - 1 <= x.ShirtLength
                &&
                userPreferences.Sleeve + 2 >= x.Sleeve && userPreferences.Sleeve - 1 <= x.Sleeve
                &&
                userPreferences.Waist + 2 >= x.Waist && userPreferences.Waist - 1 <= x.Waist
                ).ToList();
            }

            List<ShirtViewModel> model = new List<ShirtViewModel>();

            foreach (var item in modeldb)
            {
                model.Add(
                    new ShirtViewModel()
                    {
                        Arms = item.Arms,
                        Chest = item.Chest,
                        Collar = item.Collar,
                        Color = item.Color,
                        ColorType = item.ColorType,
                        Composition = item.Composition,
                        Cuff = item.Cuff,
                        Link = item.Link,
                        Made = item.Made,
                        Name = item.Name,
                        Photo = item.Photo,
                        Price = item.Price,
                        Sex = item.Sex,
                        ShirtLength = item.ShirtLength,
                        Sleeve = item.Sleeve,
                        Waist = item.Waist
                    }
                );
            }

            return View(model);
        }

        public void SaveXml(string url)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlSerializer serializer = new XmlSerializer(typeof(Koszule));

            Koszule koszula;

            using (StringReader reader = new StringReader(xmlDoc.OuterXml))
            {
                koszula = (Koszule)(serializer.Deserialize(reader));
            }

            var context = new Context();

            foreach (var made in koszula.Koszula)
            {
                foreach (var shirt in made.Produkt)
                {
                    context.Shirt.Add(
                    new ShirtModel()
                    {
                        Arms = shirt.Ramiona,
                        Chest = shirt.Klatka,
                        Collar = shirt.Kolnierzyk,
                        Color = shirt.Kolor,
                        ColorType = shirt.Kolor.Contains("-") ? "multiple" : "single",
                        Cuff = shirt.Mankiet,
                        Made = made.Producent,
                        Price = shirt.Cena,
                        Sex = made.Plec,
                        ShirtLength = shirt.DlugoscKoszuli,
                        Sleeve = shirt.Rekaw,
                        Waist = shirt.Talia,
                        Name = made.Nazwa,
                        Composition = made.Sklad,
                        Photo = shirt.Zdjecie,
                        Link = "sklep..."
                    });
                }
            }

            context.SaveChanges();
        }
    }
}