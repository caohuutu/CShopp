using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using btap.Models;

namespace btap.Areas.Admin.Controllers
{
    public class thongtinkhachhangsController : Controller
    {
        private bc_webEntities db = new bc_webEntities();

        // GET: Admin/thongtinkhachhangs
        public ActionResult Index()
        {
            return View(db.thongtinkhachhangs.ToList());
        }

        // GET: Admin/thongtinkhachhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinkhachhang thongtinkhachhang = db.thongtinkhachhangs.Find(id);
            if (thongtinkhachhang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinkhachhang);
        }

        // GET: Admin/thongtinkhachhangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/thongtinkhachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "makhachhang,tenkhachhang,sdt,diachi")] thongtinkhachhang thongtinkhachhang)
        {
            if (ModelState.IsValid)
            {
                db.thongtinkhachhangs.Add(thongtinkhachhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thongtinkhachhang);
        }

        // GET: Admin/thongtinkhachhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinkhachhang thongtinkhachhang = db.thongtinkhachhangs.Find(id);
            if (thongtinkhachhang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinkhachhang);
        }

        // POST: Admin/thongtinkhachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "makhachhang,tenkhachhang,sdt,diachi")] thongtinkhachhang thongtinkhachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thongtinkhachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thongtinkhachhang);
        }

        // GET: Admin/thongtinkhachhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thongtinkhachhang thongtinkhachhang = db.thongtinkhachhangs.Find(id);
            if (thongtinkhachhang == null)
            {
                return HttpNotFound();
            }
            return View(thongtinkhachhang);
        }

        // POST: Admin/thongtinkhachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thongtinkhachhang thongtinkhachhang = db.thongtinkhachhangs.Find(id);
            db.thongtinkhachhangs.Remove(thongtinkhachhang);
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
