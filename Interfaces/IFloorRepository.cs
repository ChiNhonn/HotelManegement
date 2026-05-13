using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.Repositories;

public interface IFloorRepository
{
    List<FloorView> GetAllGridRows();

    List<FloorView> SearchGrid(string? keyword);

    List<Branch> GetActiveBranchesOrdered();

    Floor? GetById(int id);

    void Add(Floor floor);

    void Update(Floor floor);

    void Delete(int id);

    int CountActiveRoomsOnFloor(int floorId);

    bool ExistsNameForBranch(string nameTrimmed, int? idBranch, int? excludeFloorId);
}
