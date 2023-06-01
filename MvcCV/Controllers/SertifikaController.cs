using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;

namespace MvcCV.Controllers
{
    public class SertifikaController : Controller
    {
        // GET: Sertifika
        GenericRepository<TblSertifika> repo = new GenericRepository<TblSertifika>();
        public ActionResult Index()
        {
            var sertifika = repo.List();
            return View(sertifika);
        }
        [HttpGet]
        public ActionResult SertifikaGetir(int id)
        {
            var sertifika = repo.Find(x => x.ID == id);
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifika t)
        {
            var sertifika = repo.Find(x => x.ID == t.ID);
            sertifika.Açıklama = t.Açıklama;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertifika p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        
        public ActionResult SertifikaSil(int id)
        {
            var sertifikasil = repo.Find(x => x.ID == id);
            ViewBag.d = sertifikasil.ID;
            repo.TDelete(sertifikasil);
            return RedirectToAction("Index");
        }
    }
}