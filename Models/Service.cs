using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class Service
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; } = "";

    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(500)]
    public string? ImagePath { get; set; }

    [MaxLength(50)]
    public string Unit { get; set; } = "lần";

    [Required, Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }

    public bool IsHidden { get; set; }

    public bool TrackInventory { get; set; }
    public int StockQuantity { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; } = null;
    public DateTime? SoftDelete { get; set; } = null;

    public int? IdServiceCategory { get; set; }
    [ForeignKey("IdServiceCategory")]
    public virtual ServiceCategory ServiceCategory { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; } = new List<BillDetail>();
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public virtual ICollection<ServicePriceRule> PriceRules { get; set; } = new List<ServicePriceRule>();
    public virtual ICollection<ServicePackageItem> PackageItems { get; set; } = new List<ServicePackageItem>();
    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
}
