﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDeTaiNCKH.Models;
using PagedList;

namespace QuanLyDeTaiNCKH.Controllers
{
    public class DeTaisController : Controller
    {
        private NCKHEntities db = new NCKHEntities();

        // GET: DeTais
        public ActionResult Index(string currentFilter, int?page, int loaidetai = 0, string SearchString="")
        {
            if (SearchString != "")
            {
                int pageSize = db.DeTais.Count();
                int pageNumber = (page ?? 1);
                page = 1;
                var deTais = db.DeTais.Include(d => d.NguoiDung).Include(d => d.LoaiDeTai1).Include(d => d.NguoiDung1).Where(x => x.TenDeTai.ToUpper().Contains(SearchString.ToUpper())).OrderBy(x=>x.TenDeTai);
                return View(deTais.ToPagedList(pageNumber, pageSize));
            }
            else
                SearchString = currentFilter;
            ViewBag.CurrentFilter = currentFilter;
            if (loaidetai == 0)
            {
                int pageSize = 12;
                int pageNumber = (page ?? 1);
                var deTais = db.DeTais.Include(d => d.NguoiDung).Include(d => d.LoaiDeTai1).Include(d => d.NguoiDung1).OrderBy(x => x.TenDeTai);
                return View(deTais.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                int pageSize = db.DeTais.Count();
                int pageNumber = (page ?? 1);
                var deTais = db.DeTais.Include(d => d.NguoiDung).Include(d => d.LoaiDeTai1).Include(d => d.NguoiDung1).Where(x => x.LoaiDeTai == loaidetai).OrderBy(m=>m.TenDeTai);
                return View(deTais.ToPagedList(pageNumber, pageSize));
            }
        }

        // GET: DeTais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // GET: DeTais/Create
        public ActionResult Create()
        {
            ViewBag.GiangVien = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung");
            ViewBag.LoaiDeTai = new SelectList(db.LoaiDeTais, "MaLoai", "TenLoai");
            ViewBag.SinhVien = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung");
            return View();
        }

        // POST: DeTais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDeTai,LoaiDeTai,TenDeTai,SinhVien,GiangVien,MoTa,TienDo,KetQua")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                db.DeTais.Add(deTai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GiangVien = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", deTai.GiangVien);
            ViewBag.LoaiDeTai = new SelectList(db.LoaiDeTais, "MaLoai", "TenLoai", deTai.LoaiDeTai);
            ViewBag.SinhVien = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", deTai.SinhVien);
            return View(deTai);
        }

        // GET: DeTais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            ViewBag.GiangVien = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", deTai.GiangVien);
            ViewBag.LoaiDeTai = new SelectList(db.LoaiDeTais, "MaLoai", "TenLoai", deTai.LoaiDeTai);
            ViewBag.SinhVien = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", deTai.SinhVien);
            return View(deTai);
        }

        // POST: DeTais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDeTai,LoaiDeTai,TenDeTai,SinhVien,GiangVien,MoTa,TienDo,KetQua")] DeTai deTai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deTai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GiangVien = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", deTai.GiangVien);
            ViewBag.LoaiDeTai = new SelectList(db.LoaiDeTais, "MaLoai", "TenLoai", deTai.LoaiDeTai);
            ViewBag.SinhVien = new SelectList(db.NguoiDungs, "MaNguoiDung", "TenNguoiDung", deTai.SinhVien);
            return View(deTai);
        }

        // GET: DeTais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeTai deTai = db.DeTais.Find(id);
            if (deTai == null)
            {
                return HttpNotFound();
            }
            return View(deTai);
        }

        // POST: DeTais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeTai deTai = db.DeTais.Find(id);
            db.DeTais.Remove(deTai);
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
