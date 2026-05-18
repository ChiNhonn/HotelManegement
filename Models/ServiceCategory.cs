using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class ServiceCategory
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        [MaxLength(300)]
        public string? Description { get; set; }

        public int SortOrder { get; set; }

        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = null;
        public DateTime? SoftDelete { get; set; } = null;

        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
    }
}
