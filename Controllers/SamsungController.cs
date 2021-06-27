using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btap.Models;
namespace btap.Controllers
{
    public class SamsungController : Controller
    {
        bc_webEntities db = new bc_webEntities();
        // GET: Samsung
        public ActionResult Index()
        {
            return View(db.thongtinmathangs.ToList());
        }
        public ActionResult Chitietss(int id)
        {
            var ss = db.thongtinmathangs.Find(id);
            return View(ss);

        }
    }
}