using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btap.Models;

namespace btap.Controllers
{
    public class SearchController : Controller
    {
        bc_webEntities db = new bc_webEntities();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult timkiem(string search)
        {
            return View(db.thongtinmathangs.Where(x => x.tenmathang.Contains(search) || search == null).ToList());
        }
    }
}