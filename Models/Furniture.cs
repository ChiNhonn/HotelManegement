using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models
{
    public class Furniture
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required,Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        
        public DateTime? UpdateAt { get; set; } = null;
        public DateTime? SoftDelete { get; set; } = null;

        public virtual ICollection<RoomAndFurniture> RoomAndFurnitures { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
