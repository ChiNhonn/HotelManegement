using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class DescriptionRoom
    {

        [Key]
        public int Id { get; set; }
        [MaxLength(1000)]
        public string? Content { get; set; } = null;
        [MaxLength(100)]
        public string? ImageUrl { get; set; } = null;

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = null;
        public DateTime? SoftDelete { get; set; } = null;

        public int? IdRoomType { get; set; }
        [ForeignKey("IdRoomType")]
        public virtual RoomType? RoomType { get; set; }

    }
}
