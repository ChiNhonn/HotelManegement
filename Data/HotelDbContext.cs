using HotelManagement.Interfaces;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data;

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
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=HotelManagement;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    public DbSet<RoomType> RoomTypes { get; set; } = null!;
    public DbSet<Room> Rooms { get; set; } = null!;
    public DbSet<Floor> Floors { get; set; } = null!;
    public DbSet<Voucher> Vouchers { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Bill> Bills { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Userr> Users { get; set; } = null!;
    public DbSet<Branch> Branches { get; set; } = null!;
    public DbSet<RoomAndFurniture> RoomAndFurnitures { get; set; } = null!;
    public DbSet<Furniture> Furnitures { get; set; } = null!;
    public DbSet<DescriptionRoom> DescriptionRooms { get; set; } = null!;
    public DbSet<UserProfile> UserProfiles { get; set; } = null!;
    public DbSet<BillDetail> BillDetails { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
    public DbSet<ServicePackage> ServicePackages { get; set; } = null!;
    public DbSet<ServicePackageItem> ServicePackageItems { get; set; } = null!;
    public DbSet<ServicePriceRule> ServicePriceRules { get; set; } = null!;
    public DbSet<ServiceOrder> ServiceOrders { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    public DbSet<StaffPayout> StaffPayouts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HotelDbContext).Assembly);
    }
}
