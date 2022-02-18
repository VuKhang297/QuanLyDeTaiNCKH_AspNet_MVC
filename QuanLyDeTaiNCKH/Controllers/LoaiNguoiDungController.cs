using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDeTaiNCKH.Models;
using System.Collections;

namespace QuanLyDeTaiNCKH.Controllers
{
    public class LoaiNguoiDungController : Controller
    {
        // GET: LoaiNguoiDung
        public ActionResult Index()
        {
            using (NCKHEntities db = new NCKHEntities())
            {
                OB obj1 = new OB();
                obj1.giatri = "SINHVIEN";
                obj1.hienthi = "Sinh viên";
                
                OB obj2 = new OB();
                obj2.giatri = "GIANGVIEN";
                obj2.hienthi = "Giảng viên";

                List<OB> loainguoidung = new List<OB>();
                loainguoidung.Add(obj1);
                loainguoidung.Add(obj2);
                Hashtable tenloainguoidung = new Hashtable();
                foreach (var item in loainguoidung)
                {
                    tenloainguoidung.Add(item.giatri, item.hienthi);
                }
                ViewBag.QuyenHan = tenloainguoidung;
                return PartialView("Index");
            }
        }
    }
}