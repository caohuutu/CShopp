using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using btap.Models;
namespace btap.Dao
{
    public class ctdondathangDao
    {
        bc_webEntities db = null;
        public ctdondathangDao()
        {
            db = new bc_webEntities();
        }
        public int Insert(ctdondathang detail)
        {
            //try {
            //    db.ctdondathangs.Add(detail);
            //    db.SaveChanges();
            //    return true;
            //}
            //catch {
            //    return false;

            //}
            db.ctdondathangs.Add(detail);
            db.SaveChanges();
            return detail.IDdonhang;
        }
    }
}