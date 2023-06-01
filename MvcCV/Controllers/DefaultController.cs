using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimler.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimler()
        {
            var egitimler = db.TblEğitimler.ToList();
            return PartialView(egitimler);
        }
        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobiler.ToList();
            return PartialView(hobiler);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifika = db.TblSertifika.ToList();
            return PartialView(sertifika);
        }
        [HttpGet]
        public PartialViewResult iletişim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletişim(Tbliletişim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletişim.Add(t);
            db.SaveChanges();
            return PartialView();
        }

    }
}