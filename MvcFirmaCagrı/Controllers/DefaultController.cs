using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcFirmaCagrı.Models.Entity;

namespace MvcFirmaCagrı.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        DbIsTakipEntities db = new DbIsTakipEntities();
        public ActionResult AktifCagrılar()
        {
            // burada 3vermemizin sebebi  authenticate  oldğumuz kişinin görevlerinin gelmesi istiyoruz sonra değişecek!!
            var Acagrılar = db.Cagrilartbl.Where(x => x.Durum == true ).ToList();
            return View(Acagrılar);
        }
        public ActionResult PasifCagrılar()
        {
            var Pcagrılar = db.Cagrilartbl.Where(x => x.Durum == false && x.CagriFirma == 3).ToList();
            return View(Pcagrılar);
        }
        [HttpGet]
        public  ActionResult yenicagrı()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenicagrı(Cagrilartbl p)
        {
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Durum = true;
            p.CagriFirma = 4; 
            db.Cagrilartbl.Add(p);
            db.SaveChanges();
            return RedirectToAction("AktifCagrılar");
        }
        public ActionResult cagrıdetay(int id)
        {
            var cagrı = db.CagriDetayTbl.Where(x => x.Cagri == id).ToList();
            return View(cagrı);
        }
        
    }
}