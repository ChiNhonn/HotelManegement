using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class OrderDetail
{
    [Key]
    public int Id { get; set; }
    
    [Required, MaxLength(100)]
    public string NameOrder { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }

    public int? IdCustomer { get; set; }
    [ForeignKey("IdCustomer")]
    public virtual Customer Customer { get; set; }

    public int? IdOrder { get; set; }
    [ForeignKey("IdOrder")]
    public virtual Order Order { get; set; } 

    public int? IdRoom { get; set; }
    [ForeignKey("IdRoom")]
    public virtual Room Room { get; set; }

    public int? IdService { get; set; }
    [ForeignKey("IdService")]
    public virtual Service Service { get; set; }

    public int? IdVoucher { get; set; }
    [ForeignKey("IdVoucher")]
    public virtual Voucher Voucher { get; set; }

    public int? FurnitureId { get; set; }
    [ForeignKey(nameof(FurnitureId))]
    public virtual Furniture? Furniture { get; set; }
}
