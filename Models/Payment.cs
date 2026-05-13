using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyKhachSan.Models;

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

    public int? IdBill { get; set; }
    [ForeignKey("IdBill")]
    public virtual Bill Bill { get; set; }


}
