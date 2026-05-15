using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class Floor
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }

        /// <summary>open | maintenance | closed — khóa đặt phòng cả tầng.</summary>
        [Required, MaxLength(20)]
        public string Status { get; set; } = "open";

        public virtual ICollection<Room> Rooms { get; set; }

        public int? IdBranch { get; set; }
        [ForeignKey("IdBranch")]
        public virtual Branch? Branch { get; set; }
    }
}
