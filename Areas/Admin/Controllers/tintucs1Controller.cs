using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using btap.Models;

namespace btap.Areas.Admin.Controllers
{
    public class tintucs1Controller : Controller
    {
        private bc_webEntities db = new bc_webEntities();

        // GET: Admin/tintucs1
        public ActionResult Index()
        {
            return View(db.tintucs.ToList());
        }

        // GET: Admin/tintucs1/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // GET: Admin/tintucs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/tintucs1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "matin,tieude,anhtin,noidung")] tintuc tintuc, HttpPostedFileBase anhtin)
        {
            if (anhtin != null) {
                string path = Path.Combine(Server.MapPath("~/image"), Path.GetFileName(anhtin.FileName));
                anhtin.SaveAs(path);
                tintuc.anhtin = anhtin.FileName;
            }
            if (ModelState.IsValid)
            {
                db.tintucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tintuc);
        }

        // GET: Admin/tintucs1/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: Admin/tintucs1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "matin,tieude,anhtin,noidung")] tintuc tintuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tintuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tintuc);
        }

        // GET: Admin/tintucs1/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tintuc tintuc = db.tintucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        // POST: Admin/tintucs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tintuc tintuc = db.tintucs.Find(id);
            db.tintucs.Remove(tintuc);
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
