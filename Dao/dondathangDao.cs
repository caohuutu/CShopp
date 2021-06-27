using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using btap.Models;
namespace btap.Dao
{
    public class dondathangDao
    {
        bc_webEntities db = null;
        public dondathangDao()
        {
            db = new bc_webEntities();
        }
        public int Insert(dondathang order)
        {
            using (var db = new bc_webEntities()) {
                db.dondathangs.Add(order);
                db.SaveChanges();
                return order.madondathang;
            }
        }
    }
}