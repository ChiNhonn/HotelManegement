using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }

    /// <summary>Mã khách nội bộ (nếu có).</summary>
    [MaxLength(20)]
    public string? No { get; set; }

    /// <summary>CCCD / CMND — dùng khi đặt phòng và tra cứu khách.</summary>
    [MaxLength(20)]
    public string? CitizenId { get; set; }

    [MaxLength(20)]
    public string? Phone { get; set; }

    [MaxLength(100)]
    public string? Email { get; set; }

    /// <summary>Alias CRM — map tới <see cref="CitizenId"/> (không lưu cột riêng).</summary>
    [NotMapped]
    public string CCCD
    {
        get => CitizenId ?? "";
        set => CitizenId = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }

    [MaxLength(100)]
    public string FullName { get; set; } = "";

    public DateTime BirthDay { get; set; }
    public int Gender { get; set; } // 1: nam, 0: nữ

    [MaxLength(100)]
    public string Xa { get; set; } = "";

    [MaxLength(100)]
    public string Huyen { get; set; } = "";

    [MaxLength(100)]
    public string Tinh { get; set; } = "";

    [MaxLength(100)]
    public string Country { get; set; } = "";

    [MaxLength(100)]
    public string Status { get; set; } = "";

    public int Vip { get; set; } // 2: siêu vip, 1: vip, 0: thường

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? SoftDelete { get; set; }
    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Order>? Orders { get; set; }
}