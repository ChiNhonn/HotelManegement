using Microsoft.EntityFrameworkCore;
using HotelManagement.Interfaces;
using HotelManagement.Models;

namespace HotelManagement.Data
{
    public class HotelDbContext : DbContext, IMyDbContext
    {
        public HotelDbContext()
        {
        }

        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS01;Database=HotelManagement;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
         
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelDbContext).Assembly);

            modelBuilder.Entity<Userr>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.IdUser)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoomType>()
                .HasOne(rt => rt.DescriptionRoom)
                .WithOne(dr => dr.RoomType)
                .HasForeignKey<DescriptionRoom>(dr => dr.IdRoomType)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Bill)
                .WithOne(b => b.Order)
                .HasForeignKey<Bill>(b => b.IdOrder)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoomAndFurniture>()
                .HasOne(rf => rf.Room)
                .WithMany(r => r.RoomAndFurnitures)
                .HasForeignKey(rf => rf.IdRoom)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<RoomAndFurniture>()
                .HasOne(rf => rf.Furniture)
                .WithMany(f => f.RoomAndFurnitures)
                .HasForeignKey(rf => rf.IdFurniture)
                .OnDelete(DeleteBehavior.SetNull);

        }
    
    }
    
}
