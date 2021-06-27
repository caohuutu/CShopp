using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btap.Models;

namespace btap.Areas.Admin.Controllers
{
    public class HomeadminController : Controller
    {

        bc_webEntities db = new bc_webEntities();
        // GET: Admin/Homeadmin
        public ActionResult Index()
        {
            return View();
        }

        //public ViewResult sort(string sortOrder, string searchString)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

        //    var sp = from s in db.thongtinmathangs
        //             select s;
        //    if (!String.IsNullOrEmpty(searchString)) {
        //        sp = sp.Where(s => s.tenmathang.Contains(searchString));
        //    }
        //    switch (sortOrder) {
        //        case "name_desc":
        //            sp = sp.OrderByDescending(s => s.tenmathang);
        //            break;
        //    }

        //    return View(sp.ToList());
        //}
    }
}