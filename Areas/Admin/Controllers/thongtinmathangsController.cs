using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using btap.Models;

namespace btap.Areas.Admin.Controllers
{
    public class thongtinmathangsController : Controller
    {
        private bc_webEntities db = new bc_webEntities();

        // GET: Admin/thongtinmathangs
        public ActionResult Index()
        {
            return View(db.thongtinmathangs.ToList());
        }

        // GET: Admin/thongtinmathangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinmathang thongtinmathang = db.thongtinmathangs.Find(id);
            if (thongtinmathang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinmathang);
        }

        // GET: Admin/thongtinmathangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/thongtinmathangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "mamathang,tenmathang,manhinh,hedieuhanh,chip,camera,pin,anh,RAM,bonhotrong,cnmanhinh,namramat,gia,mahangsanxuat,tinhtrang")] thongtinmathang thongtinmathang, HttpPostedFileBase anh)
        {
            if(anh!=null) {
                string path = Path.Combine(Server.MapPath("~/image"), Path.GetFileName(anh.FileName));
                anh.SaveAs(path);
                thongtinmathang.anh = anh.FileName;
            }
            if (ModelState.IsValid)
            {
                db.thongtinmathangs.Add(thongtinmathang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongtinmathang);
        }

        // GET: Admin/thongtinmathangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinmathang thongtinmathang = db.thongtinmathangs.Find(id);
            if (thongtinmathang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinmathang);
        }

        // POST: Admin/thongtinmathangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "mamathang,tenmathang,manhinh,hedieuhanh,chip,camera,pin,anh,RAM,bonhotrong,cnmanhinh,namramat,gia,mahangsanxuat,tinhtrang")] thongtinmathang thongtinmathang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongtinmathang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongtinmathang);
        }

        // GET: Admin/thongtinmathangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinmathang thongtinmathang = db.thongtinmathangs.Find(id);
            if (thongtinmathang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinmathang);
        }

        // POST: Admin/thongtinmathangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thongtinmathang thongtinmathang = db.thongtinmathangs.Find(id);
            db.thongtinmathangs.Remove(thongtinmathang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
