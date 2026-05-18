using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Voucher
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Type { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DiscountPercent { get; set; } = null;
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaxDiscountAmount { get; set; } = null;
        public int? MinNumber { get; set; } = null;
        [MaxLength(50)]
        public string? RoomType { get; set; } = null;
        [Column(TypeName = "decimal(18,2)")]
        public decimal? MinTotalPrice { get; set; } = null;
        public int? MinDay { get; set; } = null;
        public DateTime StartDate { get; set; } 
        public DateTime? EndDate { get; set; } = null;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = null;
        public DateTime? SoftDelete { get; set; } = null;

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
