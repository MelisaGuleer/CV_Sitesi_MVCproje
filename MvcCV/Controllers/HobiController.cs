using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;
using MvcCV.Repositories;


namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        // GET: Hobi
        GenericRepository<TblHobiler> repo = new GenericRepository<TblHobiler>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiler = repo.List();
            return View(hobiler);
        }
        [HttpPost]
        public ActionResult Index(TblHobiler p)
        {
            //TblHobiler t = new TblHobiler();
            var t = repo.Find(x => x.ID == 1);
            t.Açıklama1 = p.Açıklama1;
            t.Açıklama2 = p.Açıklama2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}