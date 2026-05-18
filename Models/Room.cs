using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public partial class Room
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Status { get; set; } = "available";

    public DateTime CreateAt { get; set; } = DateTime.Now;
    public DateTime? UpdateAt { get; set; } = null;
    public DateTime? SoftDelete { get; set; } = null;

    public int? IdRoomType { get; set; }

    [ForeignKey("IdRoomType")]
    public virtual RoomType? RoomType { get; set; }

    public int? IdFloor { get; set; }

    [ForeignKey("IdFloor")]
    public virtual Floor? Floor { get; set; }

    public virtual ICollection<RoomAndFurniture> RoomAndFurnitures { get; set; } = new List<RoomAndFurniture>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
