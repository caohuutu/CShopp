using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btap.Models;

namespace btap.Controllers
{
    public class HomeController : Controller
    {
        private bc_webEntities db = new bc_webEntities();
        // GET: home
        public ActionResult Index()
        {
            return View(db.thongtinmathangs.ToList());
        }
        public ActionResult Chitietsp(int id)
        {
            var sp = db.thongtinmathangs.Find(id);
            return View(sp);
        }
        public ActionResult tintuc()
        {
            return View(db.tintucs.ToList());
        }
        public ActionResult Chitiettintuc(string id)
        {
            var chitiettin = db.tintucs.Find(id);
            return View(chitiettin);
        }
        public ActionResult GTcongty()
        {
            return View();
        }
        public ActionResult tragop()
        {
            return View();
        }
        //public ActionResult hangsanxuat()
        //{
        //    var model = db.hangsanxuats;
        //    return PartialView("_hangsanxuat", model);
        //}
        //public ActionResult hangsanxuat()
        //{
        //    return View(db.hangsanxuats.ToList());
        //}
        //public ActionResult DtIphone()
        //{
        //    return View(db.thongtinmathangs.Where(x=>x.hangsanxuat.tenhangsanxuat.Contains("Iphone")).ToList());
        //}
    }
}