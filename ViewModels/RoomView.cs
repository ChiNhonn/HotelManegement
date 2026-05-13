namespace HotelManagement.ViewModels
{
    /// <summary>
    /// Dòng hiển thị danh sách phòng, khớp cột DB: Name, Status, IdRoomType, IdFloor (+ join loại/tầng).
    /// </summary>
    public class RoomView
    {
        public int MaPhong { get; set; }

        public string SoPhong { get; set; } = "";

        public string LoaiPhong { get; set; } = "";

        /// <summary>Tên tầng từ bảng Floors (Floor.Name).</summary>
        public string Tang { get; set; } = "";

        /// <summary>Trạng thái hiển thị tiếng Việt.</summary>
        public string TrangThai { get; set; } = "";
    }
}
