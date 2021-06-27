using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btap.Models;
namespace btap.Controllers
{
    public class OppoController : Controller
    {
        bc_webEntities db = new bc_webEntities();
        // GET: Oppo
        public ActionResult Index()
        {
            return View(db.thongtinmathangs.ToList());
        }
    }
}