using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Diagnostics;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Security;
using ASPBatNet.Models;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace ASPBatNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            //Response.Redirect("Logon.aspx");
            return View("Logon.aspx");
        }

        public ActionResult Index()
        {
            int brojProjekata = 0;
            for (int i = 0; i < 5; i++)
                if (!ASPBatNetModel.ListaProjekata[i].naslov.Equals(""))
                    brojProjekata++;
            ASPBatNetModel.Visibility[brojProjekata] = "visible";
            return View();
        }

        public ActionResult Profil(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        public ActionResult DodajProjekat()
        {
            ViewBag.Message = "Dodajte projekte.";

            return View();
        }
    }
}