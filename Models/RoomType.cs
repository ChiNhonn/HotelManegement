using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class RoomType
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    /// <summary>Mã ngắn hiển thị / báo giá (STD, DLX, SUI…).</summary>
    [MaxLength(20)]
    public string? Code { get; set; }

    [Required, Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }

    /// <summary>Tổng số khách tối đa (NL + TE) — đồng bộ khi lưu.</summary>
    [Required]
    public int MaxNumber { get; set; }

    /// <summary>Số người lớn tối đa.</summary>
    public int MaxAdults { get; set; } = 2;

    /// <summary>Số trẻ em tối đa.</summary>
    public int MaxChildren { get; set; }

    [MaxLength(150)]
    public string? BedTypeDescription { get; set; }

    [Required]
    public int Bed { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; } = null;
    public DateTime? SoftDelete { get; set; } = null;

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

    public virtual DescriptionRoom? DescriptionRoom { get; set; }
}
