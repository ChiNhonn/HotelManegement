using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Models;

public partial class Order
{
    [Key]
    public int Id { get; set; }

    public DateTime DateCheckIn { get; set; }
    public DateTime? DateCheckOut { get; set; } = null;
    
    public int? DepositAmount { get; set; } = null;

    [Required, MaxLength(100)]
    public string Status { get; set; } = "Pending";
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; } = null;
    public DateTime? SoftDelete { get; set; } = null;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    public int Number { get; set; }
    [MaxLength(255)]
    public string? Note { get; set; } = null;
    public int? IdCustomer { get; set; }
    [ForeignKey("IdCustomer")]
    public virtual Customer Customer { get; set; }

    public int? IdUser { get; set; }
    [ForeignKey("IdUser")]
    public virtual Userr User { get; set; }

    public virtual Bill Bill { get; set; }
}
