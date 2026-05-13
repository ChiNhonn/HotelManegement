using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTOs
{
    public class LoaiPhongView
    {
        public int MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public byte SucChuaToiDa { get; set; }
        public decimal Gia { get; set; }
        public int SoLuongPhong { get; set; }
        public string MoTa { get; set; }
    }
}
