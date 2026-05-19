using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace HotelManagement.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }

    /// <summary>Mã số khách (form quản lý khách).</summary>
    [MaxLength(20)]
    public string CCCD { get; set; }

    [MaxLength(100)]
    public string FullName { get; set; }

    public DateTime BirthDay { get; set; }
    public int Gender { get; set; } // 1: nam, 0: nữ

    [MaxLength(100)]
    public string Xa { get; set; }

    [MaxLength(100)]
    public string Huyen { get; set; }

    [MaxLength(100)]
    public string Tinh { get; set; }

    [MaxLength(100)]
    public string Country { get; set; } 

    [MaxLength(100)]
    public string Status { get; set; } 

    public int Vip { get; set; } // 2: siêu vip, 1: vip, 0: thường

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? SoftDelete { get; set; }
    public DateTime? UpdateAt { get; set; }

    public virtual ICollection<Order>? Orders { get; set; }
}
