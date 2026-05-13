using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models;

/// <summary>Ghi nhận chi trả nhân sự / quỹ (dashboard, không gắn hóa đơn).</summary>
public class StaffPayout
{
    [Key]
    public int Id { get; set; }

    /// <summary>Username hoặc tên hiển thị người nhận chi.</summary>
    [Required, MaxLength(100)]
    public string UserName { get; set; } = "";

    public decimal Amount { get; set; }

    [Required, MaxLength(50)]
    public string StatusLabel { get; set; } = "Thành công";

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; }
    public DateTime? SoftDelete { get; set; }

    [MaxLength(500)]
    public string? Note { get; set; }
}
