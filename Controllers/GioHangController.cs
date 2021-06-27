using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using btap.Dao;
using btap.foldermoi;
using btap.Models;
using System.Web.Script.Serialization;
namespace btap.Controllers
{
    public class GioHangController : Controller
    {
        private bc_webEntities db = new bc_webEntities();
        private const string CartSession = "CartSession";
        // GET: GioHang Man hinh gi be ti the nay haiz dat ten cho dung convention chu
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null) {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new {
                status = true
            });
        }

        public string Delete(int id) //xoa xong thi reload lai trang thoi
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.ttsanpham.mamathang == id);
            Session[CartSession] = sessionCart;

            return "xoa thanh cong";
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart =(List<CartItem>)Session[CartSession];
            foreach(var item in sessionCart) {
                var jsonItem = jsonCart.SingleOrDefault(x => x.ttsanpham.mamathang == item.ttsanpham.mamathang);
                if (jsonItem != null) {
                    item.Soluong = jsonItem.Soluong;
                }
                
            }
            Session[CartSession] = sessionCart;
            return Json(new 
            {
                status = true
            });
        }
        public ActionResult AddItem(int mamathang, int soluong)
        {
            var cart = Session[CartSession];
            if (cart != null) {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.ttsanpham.mamathang == mamathang)) {

                    foreach (var item in list) {
                        if (item.ttsanpham.mamathang == mamathang) 
                        {
                            item.Soluong += soluong;
                        }
                    }
                }
                else {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    var obj = db.thongtinmathangs.Find(mamathang);
                    item.ttsanpham = obj;
                    item.Soluong = soluong;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                var obj = db.thongtinmathangs.Find(mamathang);
                item.ttsanpham = obj;
                item.Soluong = soluong; 
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }


            return RedirectToAction("Index");

        }
       
    [HttpGet]
        public ActionResult hddathang()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null) {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult hddathang(string nguoinhan, string sdtnguoinhan, string diachinguoinhan, string emailnguoinhan, int makhachhang)
        {
            var ddh = new dondathang();
            var kh = new thongtinkhachhang();

            ddh.makhachhang = makhachhang;
            ddh.nguoinhan = nguoinhan;
            ddh.sdtnguoinhan = sdtnguoinhan;
            ddh.diachinguoinhan = diachinguoinhan;
            ddh.emailnguoinhan = emailnguoinhan;

            kh.makhachhang = makhachhang;
            kh.tenkhachhang = nguoinhan;
            kh.diachi = diachinguoinhan;
            kh.sdt = sdtnguoinhan;

            try {
                if(nguoinhan != "" && sdtnguoinhan != "" && diachinguoinhan != "" && emailnguoinhan != "") {
                    var id1 = new thongtinkhachhangDao().Insert(kh);
                    var id = new dondathangDao().Insert(ddh);
                    var cart = (List<CartItem>)Session[CartSession];
                    var detailDao = new btap.Dao.ctdondathangDao();

                    //foreach (CartItem item in cart) {
                    //    item.tong += (int)(item.Soluong * item.ttsanpham.gia);
                    //}
                    foreach (var item in cart) {
                        var orderDetail1 = new ctdondathang();
                        orderDetail1.IDsp = item.ttsanpham.mamathang;
                        orderDetail1.IDdonhang = id;
                        orderDetail1.gia = item.ttsanpham.gia;
                        orderDetail1.soluong = item.Soluong;
                        detailDao.Insert(orderDetail1);
                      
                    }
                    Session[CartSession] = null;
                    
                }
            }
            catch (Exception ex) {
                //return Redirect("/GioHang/thanhcong");
            }

            return Redirect("/GioHang");

        }
        public ActionResult thanhcong()
        {
            return View();
        }
        //public int tongtiendh()
        //{
            
            //var detailDao = new btap.Dao.ctdondathangDao();
            //var cart = (List<CartItem>)Session[CartSession];
            //foreach (var item in cart) {
            //    item.tong = 0;
            //    item.tong += Convert.ToInt32( item.chitietdondt.tongtien);
            //}
        //}
        
    }
   
}