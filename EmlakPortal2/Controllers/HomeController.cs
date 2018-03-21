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

        // GET: Home
        public ActionResult Index()
        {
            var evler = new List<Evler>{
                new Evler() { evId = 1, evAdi = "Antalya Ev", m2 = 250},
                new Evler() { evId = 2, evAdi = "Kemer Ev", m2 = 150 },
                new Evler() { evId = 3, evAdi = "Antakya Ev", m2 = 50 },
                new Evler() { evId = 4, evAdi = "İstanbul Ev", m2 = 350 }
            };

            return View(evler);
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
        public ActionResult Iletisim()
        {

            return View();
        }
        db01Entities db = new db01Entities();
        public ActionResult Uyeler()
        {
            List<Kayitlar> kayitListe = db.Kayitlar.ToList();
            return View(kayitListe);
        }
        public ActionResult yeniKayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniKayit(kayitModel model)
        {
            Kayitlar kayit = new Kayitlar();
            kayit.adsoyad = model.adsoyad;
            kayit.mail = model.mail;
            kayit.yas = model.yas;
            db.Kayitlar.Add(kayit);
            db.SaveChanges();
            ViewBag.sonuc = "Kayıt Yapıldı";
            return View();
        }
        public ActionResult kayitSil(int? id)
        {
            Kayitlar kayit = db.Kayitlar.Where(k => k.kayId == id).SingleOrDefault();
            db.Kayitlar.Remove(kayit);
            db.SaveChanges();
            return RedirectToAction("Uyeler");
        }
        public ActionResult kayitDuzenle(int? id)
        {
            Kayitlar kayit = db.Kayitlar.Where(k => k.kayId == id).SingleOrDefault();
            kayitModel model = new kayitModel();
            model.kayId = kayit.kayId;
            model.adsoyad = kayit.adsoyad;
            model.mail = kayit.mail;
            model.yas = kayit.yas;
            return View(model);
        }
        [HttpPost]
        public ActionResult kayitDuzenle(kayitModel m)
        {
            Kayitlar kayit = db.Kayitlar.Where(k => k.kayId == m.kayId).SingleOrDefault();
            kayit.adsoyad = m.adsoyad;
            kayit.mail = m.mail;
            kayit.yas = m.yas;
            db.SaveChanges();
            ViewBag.sonuc = "Kayıt Güncellendi";
            return View();
        }
    }
}