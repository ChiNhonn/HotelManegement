using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class Userr
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string FullName { get; set; } 
        [Required, MaxLength(50)]
        public string? UserName { get; set; } = null;

        [Required, MaxLength(255)]
        public string Password { get; set; } 
        [Required,MaxLength(50)]
        public string Role { get; set; } = "Employee";
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = null;
        public DateTime? SoftDelete { get; set; } = null;


        public int? IdBranch { get; set; }
        [ForeignKey("IdBranch")]
        public virtual Branch Branch { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
