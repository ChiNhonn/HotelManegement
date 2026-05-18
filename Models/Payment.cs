using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class Payment
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string Method { get; set; } 
    
    [Required, MaxLength(50)]
    public string Status { get; set; } = "Pending";

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; } = null;
    public DateTime? SoftDelete { get; set; } = null;

    /// <summary>Khoản thu không gắn hóa đơn (IdBill null). Với thanh toán theo HĐ có thể để null.</summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Amount { get; set; }

    public int? IdBill { get; set; }
    [ForeignKey("IdBill")]
    public virtual Bill? Bill { get; set; }


}
