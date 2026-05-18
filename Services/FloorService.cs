using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Helpers;
using HotelManagement.Models;
using HotelManagement.Repositories;
using HotelManagement.ViewModels;

namespace HotelManagement.Services;

public class FloorService : IFloorService
{
    private readonly IFloorRepository _repo;

    public FloorService(IFloorRepository repo)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    }

    public List<FloorView> GetAllGridRows() => _repo.GetAllGridRows();

    public List<FloorView> SearchGrid(string? keyword) => _repo.SearchGrid(keyword);

    public List<Branch> GetActiveBranchesOrdered() => _repo.GetActiveBranchesOrdered();

    public Floor? GetById(int id) => _repo.GetById(id);

    public int CountActiveRoomsOnFloor(int floorId) => _repo.CountActiveRoomsOnFloor(floorId);

    public void Delete(int floorId) => _repo.Delete(floorId);

    public void SetFloorOperationalStatus(int floorId, FloorOperationalMode mode) =>
        _repo.SetOperationalStatus(floorId, mode);

    public void Add(Floor floor)
    {
        // 1. Tự động ép định dạng tên tầng trước khi kiểm tra hợp lệ
        floor.Name = NormalizeFloorName(floor.Name);

        Validate(floor, null);

        if (string.IsNullOrWhiteSpace(floor.Status))
            floor.Status = FloorStatusMap.ToDatabase(FloorOperationalMode.Open);

        _repo.Add(floor);
    }

    public void Update(Floor floor)
    {
        if (floor.Id <= 0)
            throw new InvalidOperationException("Mã tầng không hợp lệ.");

        // 1. Tự động ép định dạng tên tầng trước khi kiểm tra hợp lệ
        floor.Name = NormalizeFloorName(floor.Name);

        Validate(floor, floor.Id);
        _repo.Update(floor);
    }

    private void Validate(Floor floor, int? excludeFloorId)
    {
        if (string.IsNullOrWhiteSpace(floor.Name))
            throw new InvalidOperationException("Vui lòng nhập tên tầng.");

        if (floor.IdBranch is null or <= 0)
            throw new InvalidOperationException("Vui lòng chọn chi nhánh hợp lệ.");

        if (_repo.ExistsNameForBranch(floor.Name, floor.IdBranch, excludeFloorId))
            throw new InvalidOperationException($"Tên «{floor.Name}» đã tồn tại trong hệ thống của chi nhánh này.");
    }

    private string NormalizeFloorName(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) return "";

        string remainder = input.Trim();

        if (remainder.StartsWith("tầng", StringComparison.OrdinalIgnoreCase) ||
            remainder.StartsWith("tang", StringComparison.OrdinalIgnoreCase))
        {
            remainder = remainder.Substring(4).Trim();
        }

        if (string.IsNullOrWhiteSpace(remainder)) return "Tầng";

        if (char.IsLetter(remainder[0]))
        {
            remainder = char.ToUpper(remainder[0]) + remainder.Substring(1);
        }

        return $"Tầng {remainder}";
    }
}