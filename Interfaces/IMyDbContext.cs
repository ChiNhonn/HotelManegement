using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Interfaces
{
    public interface IMyDbContext : IDisposable
    {
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Customer> Customers { get; set; }  
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Userr> Users { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<RoomAndFurniture> RoomAndFurnitures { get; set; }
        public DbSet<Furniture> Furnitures { get; set; }
        public DbSet<DescriptionRoom> DescriptionRooms { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();

    }
}

