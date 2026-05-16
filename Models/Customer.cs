using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }
    [MaxLength(20)]
    public string No { get; set; }
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
    [MaxLength(50)]
    public string Country { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? SoftDelete { get; set; } = null;
    public DateTime? UpdateAt { get; set; } = null;

    public virtual ICollection<Order> Orders { get; set; }
}
