using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using btap.Models;

namespace btap.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        bc_webEntities db = new bc_webEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            //if (Session["CPUser"] != null) {
            //    return RedirectToAction("Index", "Homeadmin");
            //}
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            var username = fc["taikhoan"];
            var password = fc["matkhau"];
            ViewBag.taikhoan = username;
            ViewBag.matkhau = password;
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)) {
                ViewBag.Error = "Không được để trống";
            }
            else {
                var user = db.nguoidung1.SingleOrDefault(m => m.taikhoan == username);
                if (user == null) {
                    ViewBag.Error = "sai tài khoản";
                }
                else {
                    if (user.matkhau != password) {
                        ViewBag.Error = "sai mật khẩu.";
                    }
                    else {
                        Session["CPUser"] = user;
                        return RedirectToAction("Index", "Homeadmin");
                    }
                }
            }
            return View();
        }
        
    }
}
