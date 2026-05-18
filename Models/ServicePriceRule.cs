using System;
using System.ComponentModel.DataAnnotations;
using HotelManagement.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public class ServicePriceRule
{
    [Key]
    public int Id { get; set; }

    public int IdService { get; set; }
    [ForeignKey(nameof(IdService))]
    public virtual Service Service { get; set; } = null!;

    [Required, MaxLength(80)]
    public string RuleName { get; set; } = "";

    /// <summary>happy_hour | peak | off_peak</summary>
    [Required, MaxLength(30)]
    public string RuleType { get; set; } = ServicePriceRuleType.OffPeak;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    /// <summary>Giờ bắt đầu (nullable = cả ngày).</summary>
    public TimeSpan? TimeStart { get; set; }
    public TimeSpan? TimeEnd { get; set; }

    public DateTime? DateStart { get; set; }
    public DateTime? DateEnd { get; set; }

    public int Priority { get; set; } = 0;

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? SoftDelete { get; set; }
}
