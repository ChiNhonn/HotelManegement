using HotelManagement.Models;
using HotelManagement.ViewModels;

namespace HotelManagement.Services;

public interface IFloorService
{
    List<FloorView> GetAllGridRows();

    List<FloorView> SearchGrid(string? keyword);

    List<Branch> GetActiveBranchesOrdered();

    void Add(Floor floor);

    void Update(Floor floor);

    void Delete(int floorId);

    int CountActiveRoomsOnFloor(int floorId);

    Floor? GetById(int id);
}
