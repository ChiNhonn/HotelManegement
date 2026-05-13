
namespace HotelManagement.ViewModels
{
    public class RoomTypeView
    {
        public int MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; } = string.Empty;
        public byte SucChuaToiDa { get; set; }
        public decimal Gia { get; set; }
        public int SoLuongPhong { get; set; }
        public string MoTa { get; set; } = string.Empty;
    }
}
