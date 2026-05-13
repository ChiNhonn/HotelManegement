using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Models;

public partial class Service
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string Name { get; set; }
    [Required, Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; } = null;
    public DateTime? SoftDelete { get; set; } = null;

    public int? IdServiceCategory { get; set; }
    [ForeignKey("IdServiceCategory")]
    public virtual ServiceCategory ServiceCategory { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
