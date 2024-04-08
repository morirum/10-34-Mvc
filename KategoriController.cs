using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _10_30.Models.Entity;

namespace _10_30.Controllers
{
    public class KategoriController : Controller
    {
        MvcDbStokEntities db = new MvcDbStokEntities();
        // GET: Kategori
        public ActionResult Index()
        {
            var degerler = db.TBLKATEGORILER1.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORİLER1 p1)
        {
            db.TBLKATEGORILER1.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var kategori = db.TBLKATEGORILER1.Find(id);
            db.TBLKATEGORILER1.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKATEGORILER1.Find(id);
            return View("KategiGetir",ktgr);
        }
        public ActionResult Guncelle (TBLKATEGORILER1 p1)
        {
            var ktg = db.TBLKATEGORILER1.Find(p1.KATEGORIID);
            ktg.KATEGORIAD = p1.KATEGORIAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}