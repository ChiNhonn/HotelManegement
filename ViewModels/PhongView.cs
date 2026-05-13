using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTOs
{
    public class PhongView
    {
        public int MaPhong { get; set; }

        public string SoPhong { get; set; }

        public string LoaiPhong { get; set; }

        public byte? Tang { get; set; }

        public string TrangThai { get; set; }

        public string GhiChu { get; set; }
    }
}
