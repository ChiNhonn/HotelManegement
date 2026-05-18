using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models;

public class ServicePackageItem
{
    [Key]
    public int Id { get; set; }

    public int IdServicePackage { get; set; }
    [ForeignKey(nameof(IdServicePackage))]
    public virtual ServicePackage ServicePackage { get; set; } = null!;

    public int IdService { get; set; }
    [ForeignKey(nameof(IdService))]
    public virtual Service Service { get; set; } = null!;

    public int Quantity { get; set; } = 1;
}
