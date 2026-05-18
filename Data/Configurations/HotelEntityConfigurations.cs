using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelManagement.Data.Configurations;

public sealed class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> b)
    {
        b.ToTable("Branches");

        b.Property(x => x.HouseNumber).HasMaxLength(50);
        b.Property(x => x.StreetName).HasMaxLength(200);
        b.Property(x => x.Commune).HasMaxLength(120);
        b.Property(x => x.City).HasMaxLength(120);
        b.Property(x => x.Country).HasMaxLength(120);
        b.Property(x => x.Phone).HasMaxLength(30);

        b.HasMany(br => br.Floors)
            .WithOne(f => f.Branch)
            .HasForeignKey(f => f.IdBranch);

        b.HasMany(br => br.Users)
            .WithOne(u => u.Branch)
            .HasForeignKey(u => u.IdBranch);

        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> b)
    {
        b.ToTable("Floors");

        b.Property(x => x.Name).HasMaxLength(100).IsRequired();

        b.HasMany(f => f.Rooms)
            .WithOne(r => r.Floor)
            .HasForeignKey(r => r.IdFloor);

        b.HasIndex(x => x.IdBranch);
    }
}

public sealed class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
{
    public void Configure(EntityTypeBuilder<RoomType> b)
    {
        b.ToTable("RoomTypes");

        b.Property(x => x.Name).HasMaxLength(100).IsRequired();
        b.Property(x => x.Code).HasMaxLength(20);
        b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        b.Property(x => x.MaxNumber).IsRequired();
        b.Property(x => x.MaxAdults).IsRequired();
        b.Property(x => x.MaxChildren).IsRequired();
        b.Property(x => x.BedTypeDescription).HasMaxLength(150);
        b.Property(x => x.Bed).IsRequired();

        b.HasIndex(x => x.Code)
            .IsUnique()
            .HasFilter("[Code] IS NOT NULL");

        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class DescriptionRoomConfiguration : IEntityTypeConfiguration<DescriptionRoom>
{
    public void Configure(EntityTypeBuilder<DescriptionRoom> b)
    {
        b.ToTable("DescriptionRooms");

        b.Property(x => x.Content).HasMaxLength(1000);
        b.Property(x => x.ImageUrl).HasMaxLength(500);

        b.HasOne(dr => dr.RoomType)
            .WithOne(rt => rt.DescriptionRoom)
            .HasForeignKey<DescriptionRoom>(dr => dr.IdRoomType)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => x.IdRoomType)
            .IsUnique()
            .HasFilter("[IdRoomType] IS NOT NULL");
    }
}

public sealed class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> b)
    {
        b.ToTable("Rooms");

        b.Property(x => x.Name).HasMaxLength(100).IsRequired();
        b.Property(x => x.Status).HasMaxLength(50).IsRequired();

        b.HasOne(r => r.RoomType)
            .WithMany(rt => rt.Rooms)
            .HasForeignKey(r => r.IdRoomType);

        b.HasIndex(x => x.IdFloor);
        b.HasIndex(x => x.IdRoomType);
        b.HasIndex(x => x.Status);
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class RoomAndFurnitureConfiguration : IEntityTypeConfiguration<RoomAndFurniture>
{
    public void Configure(EntityTypeBuilder<RoomAndFurniture> b)
    {
        b.ToTable("RoomDetail");

        b.HasOne(rf => rf.Room)
            .WithMany(r => r.RoomAndFurnitures)
            .HasForeignKey(rf => rf.IdRoom)
            .OnDelete(DeleteBehavior.SetNull);

        b.HasOne(rf => rf.Furniture)
            .WithMany(f => f.RoomAndFurnitures)
            .HasForeignKey(rf => rf.IdFurniture)
            .OnDelete(DeleteBehavior.SetNull);

        b.HasIndex(rf => new { rf.IdRoom, rf.IdFurniture })
            .IsUnique()
            .HasFilter("[IdRoom] IS NOT NULL AND [IdFurniture] IS NOT NULL");
    }
}

public sealed class FurnitureConfiguration : IEntityTypeConfiguration<Furniture>
{
    public void Configure(EntityTypeBuilder<Furniture> b)
    {
        b.ToTable("Furnitures");

        b.Property(x => x.Name).HasMaxLength(100).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");

        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> b)
    {
        b.ToTable("Customers");

        b.Property(x => x.FullName).HasMaxLength(100).IsRequired();
        b.Property(x => x.CitizenId).HasMaxLength(20).IsRequired();
        b.Property(x => x.Phone).HasMaxLength(20).IsRequired();
        b.Property(x => x.Email).HasMaxLength(100);

        b.HasIndex(x => x.CitizenId).IsUnique();
        b.HasIndex(x => x.Phone);
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class UserrConfiguration : IEntityTypeConfiguration<Userr>
{
    public void Configure(EntityTypeBuilder<Userr> b)
    {
        b.ToTable("Users");

        b.Property(x => x.FullName).HasMaxLength(100).IsRequired();
        b.Property(x => x.UserName).HasMaxLength(50);
        b.Property(x => x.Password).HasMaxLength(255).IsRequired();
        b.Property(x => x.Role).HasMaxLength(50).IsRequired();

        b.HasIndex(x => x.UserName).IsUnique();

        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
{
    public void Configure(EntityTypeBuilder<UserProfile> b)
    {
        b.ToTable("UserProfiles");

        b.Property(x => x.Email).HasMaxLength(50);
        b.Property(x => x.CitizenId).HasMaxLength(20);
        b.Property(x => x.Phone).HasMaxLength(15).IsRequired();

        b.HasOne(up => up.User)
            .WithOne(u => u.UserProfile)
            .HasForeignKey<UserProfile>(up => up.IdUser)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => x.IdUser)
            .IsUnique()
            .HasFilter("[IdUser] IS NOT NULL");
    }
}

public sealed class ServiceCategoryConfiguration : IEntityTypeConfiguration<ServiceCategory>
{
    public void Configure(EntityTypeBuilder<ServiceCategory> b)
    {
        b.ToTable("ServiceCategories");

        b.Property(x => x.Name).HasMaxLength(100).IsRequired();
        b.Property(x => x.Description).HasMaxLength(300);

        b.HasMany(c => c.Services)
            .WithOne(s => s.ServiceCategory)
            .HasForeignKey(s => s.IdServiceCategory);
    }
}

public sealed class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> b)
    {
        b.ToTable("Services");

        b.Property(x => x.Name).HasMaxLength(100).IsRequired();
        b.Property(x => x.Description).HasMaxLength(500);
        b.Property(x => x.ImagePath).HasMaxLength(500);
        b.Property(x => x.Unit).HasMaxLength(50).HasDefaultValue("lần");
        b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");

        b.HasIndex(x => x.SoftDelete);
        b.HasIndex(x => x.IsHidden);
    }
}

public sealed class ServicePackageConfiguration : IEntityTypeConfiguration<ServicePackage>
{
    public void Configure(EntityTypeBuilder<ServicePackage> b)
    {
        b.ToTable("ServicePackages");
        b.Property(x => x.Name).HasMaxLength(120).IsRequired();
        b.Property(x => x.Description).HasMaxLength(500);
        b.Property(x => x.ImagePath).HasMaxLength(500);
        b.Property(x => x.PackagePrice).HasColumnType("decimal(18,2)");
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class ServicePackageItemConfiguration : IEntityTypeConfiguration<ServicePackageItem>
{
    public void Configure(EntityTypeBuilder<ServicePackageItem> b)
    {
        b.ToTable("ServicePackageItems");
        b.HasOne(x => x.ServicePackage)
            .WithMany(p => p.Items)
            .HasForeignKey(x => x.IdServicePackage)
            .OnDelete(DeleteBehavior.Cascade);
        b.HasOne(x => x.Service)
            .WithMany(s => s.PackageItems)
            .HasForeignKey(x => x.IdService)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

public sealed class ServicePriceRuleConfiguration : IEntityTypeConfiguration<ServicePriceRule>
{
    public void Configure(EntityTypeBuilder<ServicePriceRule> b)
    {
        b.ToTable("ServicePriceRules");
        b.Property(x => x.RuleName).HasMaxLength(80).IsRequired();
        b.Property(x => x.RuleType).HasMaxLength(30).IsRequired();
        b.Property(x => x.Price).HasColumnType("decimal(18,2)");
        b.HasOne(x => x.Service)
            .WithMany(s => s.PriceRules)
            .HasForeignKey(x => x.IdService)
            .OnDelete(DeleteBehavior.Cascade);
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class ServiceOrderConfiguration : IEntityTypeConfiguration<ServiceOrder>
{
    public void Configure(EntityTypeBuilder<ServiceOrder> b)
    {
        b.ToTable("ServiceOrders");
        b.Property(x => x.ItemName).HasMaxLength(150).IsRequired();
        b.Property(x => x.Status).HasMaxLength(30).IsRequired();
        b.Property(x => x.ChargeMode).HasMaxLength(20).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        b.Property(x => x.LineTotal).HasColumnType("decimal(18,2)");
        b.Property(x => x.CancellationFee).HasColumnType("decimal(18,2)");
        b.Property(x => x.Notes).HasMaxLength(500);
        b.Property(x => x.CancelReason).HasMaxLength(500);
        b.HasIndex(x => x.Status);
        b.HasIndex(x => x.CreateAt);
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class BankTransferInboundConfiguration : IEntityTypeConfiguration<BankTransferInbound>
{
    public void Configure(EntityTypeBuilder<BankTransferInbound> b)
    {
        b.ToTable("BankTransferInbounds");
        b.Property(x => x.Amount).HasColumnType("decimal(18,2)");
        b.Property(x => x.RawContent).HasMaxLength(500).IsRequired();
        b.HasIndex(x => x.ReceivedAt);
        b.HasIndex(x => x.MatchedServiceOrderId);
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
{
    public void Configure(EntityTypeBuilder<Voucher> b)
    {
        b.ToTable("Vouchers");

        b.Property(x => x.Type).HasMaxLength(100).IsRequired();
        b.Property(x => x.DiscountPercent).HasColumnType("decimal(18,2)");
        b.Property(x => x.MaxDiscountAmount).HasColumnType("decimal(18,2)");
        b.Property(x => x.MinTotalPrice).HasColumnType("decimal(18,2)");

        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> b)
    {
        b.ToTable("Orders");

        b.Property(x => x.Status).HasMaxLength(100).IsRequired();
        b.Property(x => x.Note).HasMaxLength(255);
        b.Property(x => x.DepositAmount).HasColumnType("decimal(18,2)");

        b.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.IdCustomer);

        b.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.IdUser);

        b.HasIndex(x => x.IdCustomer);
        b.HasIndex(x => x.IdUser);
        b.HasIndex(x => x.Status);
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> b)
    {
        b.ToTable("OrderDetails");

        b.Property(x => x.NameOrder).HasMaxLength(100).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");

        b.HasOne(od => od.Customer)
            .WithMany()
            .HasForeignKey(od => od.IdCustomer);

        b.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.IdOrder);

        b.HasOne(od => od.Room)
            .WithMany(r => r.OrderDetails)
            .HasForeignKey(od => od.IdRoom);

        b.HasOne(od => od.Service)
            .WithMany(s => s.OrderDetails)
            .HasForeignKey(od => od.IdService);

        b.HasOne(od => od.Voucher)
            .WithMany(v => v.OrderDetails)
            .HasForeignKey(od => od.IdVoucher);

        b.HasOne(od => od.Furniture)
            .WithMany(f => f.OrderDetails)
            .HasForeignKey(od => od.FurnitureId);

        b.HasIndex(x => x.IdOrder);
        b.HasIndex(x => x.FurnitureId);
    }
}

public sealed class BillConfiguration : IEntityTypeConfiguration<Bill>
{
    public void Configure(EntityTypeBuilder<Bill> b)
    {
        b.ToTable("Bills");

        b.Property(x => x.Status).HasMaxLength(50).IsRequired();
        b.Property(x => x.Discount).HasColumnType("decimal(18,2)");
        b.Property(x => x.Tax).HasColumnType("decimal(18,2)");
        b.Property(x => x.TotalAmount).HasColumnType("decimal(18,2)");

        b.HasOne(bi => bi.Order)
            .WithOne(o => o.Bill)
            .HasForeignKey<Bill>(bi => bi.IdOrder)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(bi => bi.User)
            .WithMany(u => u.Bills)
            .HasForeignKey(bi => bi.IdUser);

        b.HasIndex(x => x.IdOrder)
            .IsUnique()
            .HasFilter("[IdOrder] IS NOT NULL");
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class BillDetailConfiguration : IEntityTypeConfiguration<BillDetail>
{
    public void Configure(EntityTypeBuilder<BillDetail> b)
    {
        b.ToTable("BillDetails");

        b.Property(x => x.Product).HasMaxLength(255).IsRequired();
        b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)");
        b.Property(x => x.SubTotal).HasColumnType("decimal(18,2)");

        b.HasOne(bd => bd.Bill)
            .WithMany(bi => bi.BillDetails)
            .HasForeignKey(bd => bd.IdBill);

        b.HasOne(bd => bd.Service)
            .WithMany(s => s.BillDetails)
            .HasForeignKey(bd => bd.IdService);

        b.HasIndex(x => x.IdBill);
    }
}

public sealed class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> b)
    {
        b.ToTable("Payments");

        b.Property(x => x.Method).HasMaxLength(100).IsRequired();
        b.Property(x => x.Status).HasMaxLength(50).IsRequired();

        b.HasOne(p => p.Bill)
            .WithMany(bi => bi.Payments)
            .HasForeignKey(p => p.IdBill);

        b.HasIndex(x => x.IdBill);
        b.HasIndex(x => x.SoftDelete);
    }
}

public sealed class StaffPayoutConfiguration : IEntityTypeConfiguration<StaffPayout>
{
    public void Configure(EntityTypeBuilder<StaffPayout> b)
    {
        b.ToTable("StaffPayouts");

        b.Property(x => x.UserName).HasMaxLength(100).IsRequired();
        b.Property(x => x.Amount).HasColumnType("decimal(18,2)");
        b.Property(x => x.StatusLabel).HasMaxLength(50).IsRequired();
        b.Property(x => x.Note).HasMaxLength(500);

        b.HasIndex(x => x.CreateAt);
        b.HasIndex(x => x.SoftDelete);
    }
}
