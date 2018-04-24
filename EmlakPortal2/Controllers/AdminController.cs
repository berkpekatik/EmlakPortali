using EmlakPortal2.Models;
using EmlakPortal2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakPortal2.Controllers
{
    public class AdminController : Controller
    {
        db01Entities db = new db01Entities();
        public ActionResult Index()
        {
            if (Session["oturum"] == null)
            {
                return RedirectToAction("Login");
            }
            List<ilanlar> ilanListe = db.ilanlar.ToList();
            return View(ilanListe);
        }

        public ActionResult ilanKayit()
        {
            if (Session["oturum"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }
        [HttpPost]
        public ActionResult ilanKayit(ilanModel model)
        {
            ilanlar ilan = new ilanlar();
            ilan.ilanAdi = model.ilanAdi;
            ilan.ilanYer = model.ilanYer;
            ilan.m2 = model.m2;
            ilan.fiyat = model.fiyat;
            if (model.foto != null && model.foto.ContentLength > 0)
            {
                string dosya = Guid.NewGuid().ToString();
                string uzanti = Path.GetExtension(model.foto.FileName).ToLower();
                if (uzanti != ".jpg" && uzanti != ".png" && uzanti != ".jpeg")
                {
                    ModelState.AddModelError("foto", "Dosya Uzantısı JPEG,JPG veya PNG olmalı!");
                    return View(model);
                }
                string dosyaAdi = dosya + uzanti;
                model.foto.SaveAs(Server.MapPath("~/Content/ilanResim/" + dosyaAdi));
                ilan.ilanResim = dosyaAdi;
            }
            db.ilanlar.Add(ilan);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.sonuc = "Kayıt Yapıldı";
            return View();
        }
        public ActionResult ilanSil(int? id)
        {
            if (Session["oturum"] == null)
            {
                return RedirectToAction("Login");
            }
            ilanlar ilan = db.ilanlar.Where(k => k.ilanId == id).SingleOrDefault();
            db.ilanlar.Remove(ilan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ilanDuzenle(int? id)
        {
            if (Session["oturum"] == null)
            {
                return RedirectToAction("Login");
            }
            ilanlar ilan = db.ilanlar.Where(k => k.ilanId == id).SingleOrDefault();
            ilanModel model = new ilanModel();
            model.ilanId = ilan.ilanId;
            model.ilanAdi = ilan.ilanAdi;
            model.ilanYer = ilan.ilanYer;
            model.m2 = ilan.m2;
            model.fiyat = ilan.fiyat;
            return View(model);
        }
        [HttpPost]
        public ActionResult ilanDuzenle(ilanModel m)
        {
            if (Session["oturum"] == null)
            {
                return RedirectToAction("Login");
            }
            ilanlar ilan = db.ilanlar.Where(k => k.ilanId == m.ilanId).SingleOrDefault();
            ilan.ilanAdi = m.ilanAdi;
            ilan.ilanYer = m.ilanYer;
            ilan.m2 = m.m2;
            ilan.fiyat = m.fiyat;
            db.SaveChanges();
            ViewBag.sonuc = "Kayıt Güncellendi";
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(kayitModel model)
        {

            if (model.username == "admin" && model.pass == "123")
            {
                Session["oturum"] = true;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.sonuc = "Kullanıcı Adı yada Parola Geçersiz!";
                return View();
            }
        }
        public ActionResult OturumKapat()
        {
            Session["oturum"] = null;
            return RedirectToAction("Index");
        }
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
            kayit.username = model.username;
            kayit.pass = model.pass;
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
            model.username = kayit.username;
            model.pass = kayit.pass;
            return View(model);
        }
        [HttpPost]
        public ActionResult kayitDuzenle(kayitModel m)
        {
            Kayitlar kayit = db.Kayitlar.Where(k => k.kayId == m.kayId).SingleOrDefault();
            kayit.username = m.username;
            kayit.pass = m.pass;
            db.SaveChanges();
            ViewBag.sonuc = "Kayıt Güncellendi";
            return View();
        }
        public ActionResult bannerFotoEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult bannerFotoEkle(bannerModel model)
        {
            Banner yeni = new Banner();
            yeni.baslik = model.baslik;
            yeni.aciklama = model.aciklama;
            if (model.foto != null && model.foto.ContentLength > 0)
            {
                string dosya = Guid.NewGuid().ToString();
                string uzanti = Path.GetExtension(model.foto.FileName).ToLower();
                if (uzanti != ".jpg" && uzanti != ".png" && uzanti != ".jpeg")
                {
                    ModelState.AddModelError("foto", "Dosya Uzantısı JPEG,JPG veya PNG olmalı!");
                    return View(model);
                }
                string dosyaAdi = dosya + uzanti;
                model.foto.SaveAs(Server.MapPath("~/Content/Banner/" + dosyaAdi));
                yeni.resimYol = dosyaAdi;
            }
            db.Banner.Add(yeni);
            db.SaveChanges();
            ModelState.Clear();
            ViewBag.sonuc = "Fotoğraf Eklendi";
            return View();
        }
        public ActionResult bannerListele()
        {
            if (Session["oturum"] == null)
            {
                return RedirectToAction("Login");
            }
            List<Banner> bannerListe = db.Banner.ToList();
            return View(bannerListe);
        }
        public ActionResult bannerFotoSil(int? id)
        {
            if (Session["oturum"] == null)
            {
                return RedirectToAction("Login");
            }
            Banner kayit = db.Banner.Where(k => k.Id == id).SingleOrDefault();
            if (kayit == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                string resimYol = Server.MapPath("~/Content/Banner/" +
               kayit.resimYol);
                if (System.IO.File.Exists(resimYol))
                {
                    System.IO.File.Delete(resimYol);
                }
                db.Banner.Remove(kayit);
                db.SaveChanges();
                return RedirectToAction("Listele");
            }
        }

    }
}

