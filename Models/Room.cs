using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Models;

public partial class Room
{
    [Key]
    public int Id { get; set; }

    [NotMapped]
    public int MaPhong
    {
        get => Id;
        set => Id = value;
    }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [NotMapped]
    public string SoPhong
    {
        get => Name;
        set => Name = value;
    }

    [Required, MaxLength(50)]
    public string Status { get; set; } = "available";

    [NotMapped]
    public string TrangThai
    {
        get => Status;
        set => Status = value;
    }

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; } = null;
    public DateTime? SoftDelete { get; set; } = null;

    public int? IdRoomType { get; set; }

    [NotMapped]
    public int? MaLoaiPhong
    {
        get => IdRoomType;
        set => IdRoomType = value;
    }

    [ForeignKey("IdRoomType")]
    public virtual RoomType? RoomType { get; set; }

    public int? IdFloor { get; set; }

    [NotMapped]
    public byte? Tang { get; set; }

    [NotMapped]
    public string? GhiChu { get; set; }

    [ForeignKey("IdFloor")]
    public virtual Floor? Floor { get; set; }


    public virtual ICollection<RoomAndFurniture> RoomAndFurnitures { get; set; } = new List<RoomAndFurniture>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
