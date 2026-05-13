using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string CitizenId { get; set; }
        
        [Required, MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(20)]
        public string? HouseNumber { get; set; } = null;
        [MaxLength(20)]
        public string? StreetName { get; set; } = null;
        [MaxLength(20)]
        public string? Commune { get; set; } = null;
        [MaxLength(20)]
        public string? City { get; set; } = null;
        [MaxLength(20)]
        public string? Country { get; set; } = null;
        
        public DateTime? DateOfBirth { get; set; } = null;
        public int? Gender { get; set; } = null; //1 Nam , 2 Nữ, 3 Khác
        [MaxLength(200)]
        public string? Avatar { get; set; } = null;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; } = null;
        public DateTime? SoftDelete { get; set; } = null;

        public int? IdUser { get; set; }
        [ForeignKey("IdUser")]
        public virtual Userr User { get; set; }  
    }
}
