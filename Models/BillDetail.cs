using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class BillDetail
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required, Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        [Required, Column(TypeName = "decimal(18, 2)")]
        public decimal SubTotal { get; set; }

        public int? IdBill { get; set; }
        [ForeignKey("IdBill")]
        public virtual Bill Bill { get; set; }

        public int? IdService { get; set; }
        [ForeignKey("IdService")]
        public virtual Service Service { get; set; }
    }
}
