using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _10_30.Models.Entity;
namespace MvcDbStok.Controllers
{
    namespace _10_30.Controllers
    {
        public class UrunController : Controller
        {
            // GET: Urun
            MvcDbStokEntities db = new MvcDbStokEntities();

            public ActionResult Index()
            {
                var degerler = db.TBLURUNLER.ToList();
                return View(degerler);
            }
            [HttpGet]
            public ActionResult UrunEkle()
            {
                List<SelectListItem> degerler = (from i in db.TBLKATEGORILER1.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = i.KATEGORIAD,
                                                     Value = i.KATEGORIID.ToString()

                                                 }).ToList();                                                                                              )
                ViewBag.dgr = degerler;
                return View();
            }
            [HttpPost]
            public ActionResult UrunEkle(TBLURUNLER p1)
            {
                var ktg = db.TBLKATEGORILER1.Where(m => m.KATEGORIID == p1.TBLKATEGORIILER.KATEGORILERID).FirstOrDefault;
                p1.TBLKATEGORILER = ktg;
                db.TBLURUNLER.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            public ActionResult SIL(int id)
            {
                var urun = db.TBLKATEGORILER1.Find(id);
                db.TBLKATEGORILER1.Remove(urun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


        }
    }




}

