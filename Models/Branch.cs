using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Branch
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(20)]
        public string HouseNumber { get; set; }
        [Required, MaxLength(20)]
        public string StreetName { get; set; }
        [Required, MaxLength(20)]
        public string Commune { get; set; }
        [Required, MaxLength(20)]
        public string City { get; set; }
        [Required, MaxLength(20)]
        public string Country { get; set; }
        [Required, MaxLength(20)]
        public string Phone { get; set; }
        
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = null;
        public DateTime? SoftDelete { get; set; } = null;


        public virtual ICollection<Floor> Floors { get; set; }

        public virtual ICollection<Userr> Users { get; set; }
    }
}
