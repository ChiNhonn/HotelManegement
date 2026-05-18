using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public class ServicePackage
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(120)]
    public string Name { get; set; } = "";

    [MaxLength(500)]
    public string? Description { get; set; }

    [MaxLength(500)]
    public string? ImagePath { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal PackagePrice { get; set; }

    public bool IsHidden { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; }
    public DateTime? SoftDelete { get; set; }

    public virtual ICollection<ServicePackageItem> Items { get; set; } = new List<ServicePackageItem>();
    public virtual ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
}
