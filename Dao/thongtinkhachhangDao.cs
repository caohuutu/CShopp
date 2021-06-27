using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using btap.Models;
namespace btap.Dao
{
    public class thongtinkhachhangDao
    {
        bc_webEntities db = null;
        public thongtinkhachhangDao()
        {
            db = new bc_webEntities();
        }
        public int Insert(thongtinkhachhang order)
        {
            db.thongtinkhachhangs.Add(order);
            db.SaveChanges();
            return order.makhachhang;
        }
    }
}