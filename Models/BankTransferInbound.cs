using System;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models;

/// <summary>Ghi nhận một biến động chuyển khoản (webhook / đối soát) để tự khớp đơn « thanh toán ngay ».</summary>
public class BankTransferInbound
{
    [Key]
    public int Id { get; set; }

    [Required]
    public decimal Amount { get; set; }

    /// <summary>Nội dung chuyển khoản — nên chứa #DV{id} để khớp chính xác.</summary>
    [Required, MaxLength(500)]
    public string RawContent { get; set; } = "";

    public DateTime ReceivedAt { get; set; } = DateTime.Now;

    public int? MatchedServiceOrderId { get; set; }

    public DateTime? ProcessedAt { get; set; }

    public DateTime? SoftDelete { get; set; }
}
