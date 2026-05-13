using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    [Table("RoomDetail")]
    public class RoomAndFurniture
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public int Quantity { get; set; }
        public int? IdRoom { get; set; }
        [ForeignKey("IdRoom")]
        public virtual Room Room { get; set; }

        public int? IdFurniture { get; set; }
        [ForeignKey("IdFurniture")]
        public virtual Furniture Furniture { get; set; }
    }
}
