//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyDeTaiNCKH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeTai
    {
        public int MaDeTai { get; set; }
        public int LoaiDeTai { get; set; }
        public string TenDeTai { get; set; }
        public int SinhVien { get; set; }
        public int GiangVien { get; set; }
        public string MoTa { get; set; }
        public string TienDo { get; set; }
        public string KetQua { get; set; }
    
        public virtual NguoiDung NguoiDung { get; set; }
        public virtual LoaiDeTai LoaiDeTai1 { get; set; }
        public virtual NguoiDung NguoiDung1 { get; set; }
    }
}