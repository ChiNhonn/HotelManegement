using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.ViewModels;

namespace HotelManagement.Services;

public class FloorService : IFloorService
{
    private readonly IFloorRepository _repo;

    public FloorService(IFloorRepository repo)
    {
        _repo = repo;
    }

    public List<FloorView> GetAllGridRows() => _repo.GetAllGridRows();

    public List<FloorView> SearchGrid(string? keyword) => _repo.SearchGrid(keyword);

    public List<Branch> GetActiveBranchesOrdered() => _repo.GetActiveBranchesOrdered();

    public Floor? GetById(int id) => _repo.GetById(id);

    private void Validate(Floor floor, int? excludeFloorId)
    {
        if (string.IsNullOrWhiteSpace(floor.Name))
            throw new InvalidOperationException("Nhập tên tầng.");

        if (floor.IdBranch is null or <= 0)
            throw new InvalidOperationException("Chọn chi nhánh.");

        var name = floor.Name.Trim();
        if (_repo.ExistsNameForBranch(name, floor.IdBranch, excludeFloorId))
            throw new InvalidOperationException("Đã có tầng cùng tên trong chi nhánh này.");
    }

    public void Add(Floor floor)
    {
        Validate(floor, null);
        floor.Name = floor.Name.Trim();
        _repo.Add(floor);
    }

    public void Update(Floor floor)
    {
        if (floor.Id <= 0)
            throw new InvalidOperationException("Mã tầng không hợp lệ.");

        Validate(floor, floor.Id);
        floor.Name = floor.Name.Trim();
        _repo.Update(floor);
    }

    public void Delete(int floorId) => _repo.Delete(floorId);

    public int CountActiveRoomsOnFloor(int floorId) => _repo.CountActiveRoomsOnFloor(floorId);
}
