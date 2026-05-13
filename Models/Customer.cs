using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(100)]
    public string FullName { get; set; }
    [Required, MaxLength(20)]
    public string CitizenId { get; set; }
    [Required, MaxLength(20)]
    public string Phone { get; set; }
    [MaxLength(100)]
    public string? Email { get; set; } = null;
    [MaxLength(20)]
    public string? HouseNumber { get; set; } = null;
    [MaxLength(20)]
    public string? StreetName { get; set; } = null;
    [MaxLength(20)]
    public string? Commune { get; set; } = null;
    [MaxLength(20)]
    public string? City { get; set; } = null;
    [MaxLength(20)]
    public string? Country { get; set; } = null;
    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? SoftDelete { get; set; } = null;
    public DateTime? UpdateAt { get; set; } = null;

    public virtual ICollection<Order> Orders { get; set; }
}
