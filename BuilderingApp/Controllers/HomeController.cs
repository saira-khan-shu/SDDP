using BuilderingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuilderingApp.Controllers
{
    public class HomeController : Controller
    {
        private RouteDBContext db = new RouteDBContext();
        public ActionResult Index()
        {
            ViewBag.Routes = db.Routes.ToList(); 
            return View(); // try to provide routes here somehow 
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
    }
}