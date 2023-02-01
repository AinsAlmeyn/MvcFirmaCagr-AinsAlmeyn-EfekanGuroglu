using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcFirmaCagrı.Models.Entity;

namespace MvcFirmaCagrı.Controllers
{
    public class LoginController : Controller
    {
        DbIsTakipEntities db = new DbIsTakipEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblFirmalar f)
        {
            var bilgiler = db.TblFirmalar.FirstOrDefault(x => x.Mail == f.Mail && x.Sifre == f.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
                Session["Mail"] = bilgiler.Mail.ToString();
                return RedirectToAction("AktifCagrılar", "Default");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}