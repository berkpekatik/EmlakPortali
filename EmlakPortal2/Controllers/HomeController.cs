using EmlakPortal2.Models;
using EmlakPortal2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakPortal2.Controllers
{
    public class HomeController : Controller
    {
        db01Entities db = new db01Entities();
        // GET: Home
        public ActionResult Index()
        {
            List<Banner> bannerListe = db.Banner.ToList();           
            return View(bannerListe);
            
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Iletisim()
        {

            return View();
        }
        public ActionResult ilanlar()
        {
            List<ilanlar> ilanListe = db.ilanlar.ToList();
            return View(ilanListe);
        }
        

    }
}