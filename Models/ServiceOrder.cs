using System;
using System.ComponentModel.DataAnnotations;
using HotelManagement.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public class ServiceOrder
{
    [Key]
    public int Id { get; set; }

    public int IdOrder { get; set; }
    [ForeignKey(nameof(IdOrder))]
    public virtual Order Order { get; set; } = null!;

    public int IdRoom { get; set; }
    [ForeignKey(nameof(IdRoom))]
    public virtual Room Room { get; set; } = null!;

    public int? IdService { get; set; }
    [ForeignKey(nameof(IdService))]
    public virtual Service? Service { get; set; }

    public int? IdServicePackage { get; set; }
    [ForeignKey(nameof(IdServicePackage))]
    public virtual ServicePackage? ServicePackage { get; set; }

    [Required, MaxLength(150)]
    public string ItemName { get; set; } = "";

    public int Quantity { get; set; } = 1;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal LineTotal { get; set; }

    [Required, MaxLength(30)]
    public string Status { get; set; } = ServiceOrderStatus.Pending;

    /// <summary>folio | immediate</summary>
    [Required, MaxLength(20)]
    public string ChargeMode { get; set; } = ServiceChargeMode.Folio;

    public bool IsPostedToBill { get; set; }
    public int? IdBillDetail { get; set; }

    [MaxLength(500)]
    public string? Notes { get; set; }

    [MaxLength(500)]
    public string? CancelReason { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal CancellationFee { get; set; }

    public int? IdUser { get; set; }
    [ForeignKey(nameof(IdUser))]
    public virtual Userr? User { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? CancelledAt { get; set; }
    public DateTime? SoftDelete { get; set; }
}
