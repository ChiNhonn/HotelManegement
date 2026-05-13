using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class RoomType
{
    [Key]
    public int Id { get; set; }

    [NotMapped]
    public int MaLoaiPhong
    {
        get => Id;
        set => Id = value;
    }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [NotMapped]
    public string TenLoaiPhong
    {
        get => Name;
        set => Name = value;
    }

    [Required,Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }

    [NotMapped]
    public decimal GiaCoBan
    {
        get => UnitPrice;
        set => UnitPrice = value;
    }

    [Required]
    public int MaxNumber { get; set; }

    [NotMapped]
    public byte SucChuaToiDa
    {
        get => (byte)MaxNumber;
        set => MaxNumber = value;
    }

    [Required]
    public int Bed { get; set; }

    [NotMapped]
    public string? MoTa
    {
        get => DescriptionRoom?.Content;
        set
        {
            if (DescriptionRoom == null)
            {
                DescriptionRoom = new DescriptionRoom();
            }

            DescriptionRoom.Content = value;
        }
    }

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; } = null;
    public DateTime? SoftDelete { get; set; } = null;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual DescriptionRoom? DescriptionRoom { get; set; }
}
