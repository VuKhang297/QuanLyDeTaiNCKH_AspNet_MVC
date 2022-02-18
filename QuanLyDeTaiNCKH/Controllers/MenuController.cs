using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDeTaiNCKH.Models;
using System.Collections;

namespace QuanLyDeTaiNCKH.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            using(NCKHEntities db = new NCKHEntities())
            {
                var loaidetai = db.LoaiDeTais.ToList();
                Hashtable tenloaidetai = new Hashtable();
                foreach(var item in loaidetai)
                {
                    tenloaidetai.Add(item.MaLoai, item.TenLoai);
                }
                ViewBag.TenLoai = tenloaidetai;
                return PartialView("Index");
            }
        }
    }
}