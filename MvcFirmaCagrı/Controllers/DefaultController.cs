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
            var mail = (string)Session["Mail"];
            // ViewBag.m = Mail;
            var id = db.TblFirmalar.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault(); 
            // burada 3vermemizin sebebi  authenticate  oldğumuz kişinin görevlerinin gelmesi istiyoruz sonra değişecek!!
            var Acagrılar = db.Cagrilartbl.Where(x => x.Durum == true && x.CagriFirma ==id).ToList();
            return View(Acagrılar);
        }
        public ActionResult PasifCagrılar()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirmalar.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var Pcagrılar = db.Cagrilartbl.Where(x => x.Durum == false && x.CagriFirma==id ).ToList();
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
            var mail = (string)Session["Mail"];
            var id = db.TblFirmalar.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            p.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.Durum = true;
            p.CagriFirma = id; 
            db.Cagrilartbl.Add(p);
            db.SaveChanges();
            return RedirectToAction("AktifCagrılar");
        }
        public ActionResult cagrıdetay(int id)
        {
            var cagrı = db.CagriDetayTbl.Where(x => x.Cagri == id).ToList();
            return View(cagrı);
        }
        public ActionResult cagrıgetir(int id)
        {
            var cagrı = db.Cagrilartbl.Find(id);
            return View("cagrıgetir", cagrı);
;        }
        public ActionResult CagrıyıDuzenle(Cagrilartbl c)
        {
            var cagrı = db.Cagrilartbl.Find(c.ID);
            cagrı.Konu=c.Konu;
            cagrı.Aciklama = c.Aciklama;
            db.SaveChanges();
            return RedirectToAction("AktifCagrılar");
;
        }
        [HttpGet]
        public ActionResult ProfilDuzenle()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirmalar.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();

            var profil = db.TblFirmalar.Where(x => x.ID == id).FirstOrDefault();
            return View(profil);
        }
        public ActionResult AnaSayfa()
        {
            var mail = (string)Session["Mail"];
            var id = db.TblFirmalar.Where(x => x.Mail == mail).Select(y => y.ID).FirstOrDefault();
            var toplamCagrı = db.Cagrilartbl.Where(x => x.CagriFirma == id).Count();
            var AktifCagrı = db.Cagrilartbl.Where(x => x.CagriFirma == id && x.Durum==true).Count();
            var PasifCagrı = db.Cagrilartbl.Where(x => x.CagriFirma == id && x.Durum==false).Count();
            var Yetkili = db.TblFirmalar.Where(x => x.ID == id ).Select(y => y.Yetkili ).FirstOrDefault();
            var Sektor = db.TblFirmalar.Where(x => x.ID == id ).Select(y => y.Sektor ).FirstOrDefault();
            
            ViewBag.c1 = toplamCagrı;
            ViewBag.c2 = AktifCagrı;
            ViewBag.c3 = PasifCagrı;
            ViewBag.c4 = Yetkili;
            ViewBag.c5 = Sektor ;
            return View();
        }

    }
}