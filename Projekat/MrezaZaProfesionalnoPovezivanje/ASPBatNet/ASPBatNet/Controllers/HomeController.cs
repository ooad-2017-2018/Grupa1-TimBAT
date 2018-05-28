using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPBatNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profil(string username, string password)
        {
            System.Diagnostics.Debug.WriteLine(username + " " + password);
            if (username.Equals("Adnan"))
                return View("~/Views/Home/Index.cshtml");
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}