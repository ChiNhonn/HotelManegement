using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class Bill
{
    [Key]
    public int Id { get; set; }

    public DateTime CreateAt { get; set; } = DateTime.Now;
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Discount { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Tax { get; set; }
    [Column(TypeName = "decimal(18, 2)")] 
    public decimal TotalAmount { get; set; }

    public DateTime? SoftDelete { get; set; } = null;

    [Required]
    public string Status { get; set; } = "Pending";

    public int? IdUser { get; set; }
    [ForeignKey("IdUser")]
    public virtual Userr User { get; set; }

    public int? IdOrder { get; set; }
    [ForeignKey("IdOrder")]
    public virtual Order Order { get; set; }

    public virtual ICollection<BillDetail> BillDetails { get; set; }
    public virtual ICollection<Payment> Payments  { get; set; }
}
