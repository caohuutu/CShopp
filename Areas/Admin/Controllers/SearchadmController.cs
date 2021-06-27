using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btap.Models;
namespace btap.Areas.Admin.Controllers
{
    public class SearchadmController : Controller
    {
        bc_webEntities db = new bc_webEntities();
        // GET: Admin/Searchadm
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult timkiemadm(string search)
        {
            return View(db.thongtinmathangs.Where(x => x.tenmathang.Contains(search) || search == null).ToList());
        }
    }
}