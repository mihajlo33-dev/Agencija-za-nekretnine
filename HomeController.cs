using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication111.Controllers
{
    public class HomeController : Controller
    {
        MainLogic.MainLogic Logic = null;

        public HomeController()
        {
            Logic = new MainLogic.MainLogic();
            
        }

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

        [HttpPost]
        public JsonResult SnimiPoruku(string Ime, string Email, string GlavnaPoruka)
        {

            Logic.SnimiPoruku(Ime, Email, GlavnaPoruka);

            return Json("OK", JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult SnimiEmail(string email1)
        {

            Logic.SnimiEmail(email1);

            return Json("GREAT", JsonRequestBehavior.AllowGet);

        }
    }
}