using HotelManagement.Data;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Repositories;

public class FloorRepository : IFloorRepository
{
    private readonly HotelDbContext _context;

    public FloorRepository(HotelDbContext context)
    {
        _context = context;
    }

    public List<Branch> GetActiveBranchesOrdered()
    {
        return _context.Branches.AsNoTracking()
            .Where(b => b.SoftDelete == null)
            .OrderBy(b => b.City)
            .ThenBy(b => b.Id)
            .ToList();
    }

    public Floor? GetById(int id)
    {
        return _context.Floors.AsNoTracking()
            .Include(f => f.Branch)
            .FirstOrDefault(f => f.Id == id);
    }

    private Dictionary<int, int> ActiveRoomCountsByFloor()
    {
        return _context.Rooms.AsNoTracking()
            .Where(r => r.SoftDelete == null && r.IdFloor != null)
            .GroupBy(r => r.IdFloor!.Value)
            .Select(g => new { FloorId = g.Key, C = g.Count() })
            .ToDictionary(x => x.FloorId, x => x.C);
    }

    private List<FloorView> MapRows(List<Floor> floors, Dictionary<int, int> counts)
    {
        return floors.Select(f => new FloorView
        {
            FloorId = f.Id,
            FloorName = f.Name ?? "",
            BranchDisplayName = BranchDisplayHelper.Format(f.Branch),
            RoomCount = counts.TryGetValue(f.Id, out var c) ? c : 0,
            IdBranch = f.IdBranch,
        }).ToList();
    }

    public List<FloorView> GetAllGridRows()
    {
        var floors = _context.Floors.AsNoTracking()
            .Include(f => f.Branch)
            .OrderBy(f => f.Name)
            .ToList();
        return MapRows(floors, ActiveRoomCountsByFloor());
    }

    public List<FloorView> SearchGrid(string? keyword)
    {
        var floors = _context.Floors.AsNoTracking()
            .Include(f => f.Branch)
            .OrderBy(f => f.Name)
            .ToList();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            var k = keyword.Trim();
            floors = floors.Where(f =>
                (f.Name != null && f.Name.Contains(k, StringComparison.OrdinalIgnoreCase))
                || (f.Branch != null && BranchDisplayHelper.Format(f.Branch).Contains(k, StringComparison.OrdinalIgnoreCase))
                || f.Id.ToString().Contains(k, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        return MapRows(floors, ActiveRoomCountsByFloor());
    }

    public void Add(Floor floor)
    {
        _context.Floors.Add(floor);
        _context.SaveChanges();
    }

    public void Update(Floor floor)
    {
        var e = _context.Floors.FirstOrDefault(x => x.Id == floor.Id);
        if (e == null)
            throw new InvalidOperationException("Không tìm thấy tầng.");

        e.Name = floor.Name;
        e.IdBranch = floor.IdBranch;
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var e = _context.Floors.FirstOrDefault(x => x.Id == id);
        if (e == null)
            throw new InvalidOperationException("Không tìm thấy tầng.");

        if (CountActiveRoomsOnFloor(id) > 0)
            throw new InvalidOperationException("Tầng đang có phòng, không thể xóa.");

        _context.Floors.Remove(e);
        _context.SaveChanges();
    }

    public int CountActiveRoomsOnFloor(int floorId)
    {
        return _context.Rooms.Count(r => r.IdFloor == floorId && r.SoftDelete == null);
    }

    public bool ExistsNameForBranch(string nameTrimmed, int? idBranch, int? excludeFloorId)
    {
        var n = nameTrimmed.Trim();
        var q = _context.Floors.AsQueryable().Where(f => f.Name != null && f.Name.Trim() == n && f.IdBranch == idBranch);
        if (excludeFloorId is { } ex)
            q = q.Where(f => f.Id != ex);
        return q.Any();
    }
}
