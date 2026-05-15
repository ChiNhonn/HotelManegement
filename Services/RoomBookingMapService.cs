using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Services;

public sealed class RoomBookingMapService : IRoomBookingMapService
{
    private const int UnassignedFloorKey = int.MinValue;

    private readonly IRoomBookingMapRepository _repo;

    public RoomBookingMapService(IRoomBookingMapRepository repo)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    }

    public DashboardMiniRoomStatus GetMiniRoomStatusAsOf(DateTime asOfDate)
    {
        var day = asOfDate.Date;
        var guestByRoom = _repo.GetGuestStayMapForDate(day);
        var floors = _repo.GetActiveFloorsOrdered();
        var allRooms = _repo.GetActiveRoomsWithTypes();

        var floorIndex = floors.Select((f, i) => (f.Id, i)).ToDictionary(t => t.Id, t => t.i);
        var rowLabels = floors.Select(f => f.Name).ToList();
        var floorStatusById = floors.ToDictionary(f => f.Id, f => f.Status);

        var hasUnassigned = allRooms.Any(r => r.IdFloor == null);
        if (hasUnassigned)
            rowLabels.Add("Chưa gán tầng");

        var unassignedRow = floors.Count;

        var roomsByFloor = allRooms
            .GroupBy(r => r.IdFloor ?? UnassignedFloorKey)
            .ToDictionary(
                g => g.Key,
                g => g.OrderBy(r => r.Name, StringComparer.OrdinalIgnoreCase).ToList());

        var cells = new List<DashboardMiniRoomCell>();

        foreach (var floor in floors)
        {
            if (!floorIndex.TryGetValue(floor.Id, out var row))
                continue;

            if (!roomsByFloor.TryGetValue(floor.Id, out var onFloor))
                onFloor = new List<RoomBookingMapRoomRow>();

            floorStatusById.TryGetValue(floor.Id, out var floorStatus);

            for (var col = 0; col < onFloor.Count; col++)
            {
                cells.Add(BuildCell(onFloor[col], row, col, guestByRoom, floorStatus));
            }
        }

        if (hasUnassigned && roomsByFloor.TryGetValue(UnassignedFloorKey, out var unassigned))
        {
            for (var col = 0; col < unassigned.Count; col++)
                cells.Add(BuildCell(unassigned[col], unassignedRow, col, guestByRoom, "open"));
        }

        return new DashboardMiniRoomStatus
        {
            Rooms = cells,
            FloorRowLabels = rowLabels,
            VacantCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Vacant),
            OccupiedCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Occupied),
            CleaningCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Cleaning),
            MaintenanceCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Maintenance),
            UnknownCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Unknown)
        };
    }

    private static DashboardMiniRoomCell BuildCell(
        RoomBookingMapRoomRow room,
        int gridRow,
        int gridCol,
        Dictionary<int, (string GuestName, int OrderId)> guestByRoom,
        string? floorStatus)
    {
        string? guest = null;
        int? activeOrderId = null;
        if (guestByRoom.TryGetValue(room.Id, out var stay))
        {
            guest = stay.GuestName;
            activeOrderId = stay.OrderId;
        }

        var phys = RoomStatusMap.ClassifyPhysicalKind(room.Status);

        var kind = phys switch
        {
            _ when FloorStatusMap.IsLockedForBooking(floorStatus) => RoomPhysicalStatusKind.Maintenance,
            RoomPhysicalStatusKind.Maintenance => RoomPhysicalStatusKind.Maintenance,
            _ when guest != null || phys == RoomPhysicalStatusKind.Occupied => RoomPhysicalStatusKind.Occupied,
            _ => phys
        };

        if (!RoomBookingRules.IsRoomBookable(room.Status) && kind == RoomPhysicalStatusKind.Vacant)
            kind = RoomPhysicalStatusKind.Maintenance;

        return new DashboardMiniRoomCell
        {
            RoomId = room.Id,
            Name = string.IsNullOrWhiteSpace(room.Name) ? $"#{room.Id}" : room.Name.Trim(),
            RawStatus = room.Status ?? "",
            Kind = kind,
            GuestName = guest,
            ActiveOrderId = activeOrderId,
            IdRoomType = room.IdRoomType,
            RoomTypeName = string.IsNullOrWhiteSpace(room.TypeName) ? null : room.TypeName.Trim(),
            NightlyPrice = room.NightlyPrice,
            GridRow = gridRow,
            GridCol = gridCol
        };
    }

    public DashboardMiniRoomStatus ApplyViewFilters(DashboardMiniRoomStatus full,
        RoomBookingMapFilterCriteria criteria)
    {
        ArgumentNullException.ThrowIfNull(full);
        criteria ??= new RoomBookingMapFilterCriteria { StatusFilter = RoomBookingMapStatusFilterKind.All };

        IEnumerable<DashboardMiniRoomCell> q = full.Rooms;

        switch (criteria.StatusFilter)
        {
            case RoomBookingMapStatusFilterKind.VacantOnly:
                q = q.Where(c => c.Kind == RoomPhysicalStatusKind.Vacant);
                break;
            case RoomBookingMapStatusFilterKind.CleaningOnly:
                q = q.Where(c => c.Kind == RoomPhysicalStatusKind.Cleaning);
                break;
        }

        if (criteria.RoomTypeId is { } rtId)
            q = q.Where(c => c.IdRoomType == rtId);

        var search = criteria.SearchText?.Trim() ?? "";
        if (search.Length > 0)
        {
            q = q.Where(c =>
                c.Name.Contains(search, StringComparison.OrdinalIgnoreCase)
                || (c.GuestName != null
                    && c.GuestName.Contains(search, StringComparison.OrdinalIgnoreCase)));
        }

        var list = q.ToList();
        return new DashboardMiniRoomStatus
        {
            Rooms = list,
            FloorRowLabels = full.FloorRowLabels,
            VacantCount = list.Count(c => c.Kind == RoomPhysicalStatusKind.Vacant),
            OccupiedCount = list.Count(c => c.Kind == RoomPhysicalStatusKind.Occupied),
            CleaningCount = list.Count(c => c.Kind == RoomPhysicalStatusKind.Cleaning),
            MaintenanceCount = list.Count(c => c.Kind == RoomPhysicalStatusKind.Maintenance),
            UnknownCount = list.Count(c => c.Kind == RoomPhysicalStatusKind.Unknown)
        };
    }

    public IReadOnlyList<RoomBookingMapRoomTypeOption> GetRoomTypeFilterOptions(DashboardMiniRoomStatus full)
    {
        ArgumentNullException.ThrowIfNull(full);
        return full.Rooms
            .Where(r => r.IdRoomType != null && !string.IsNullOrWhiteSpace(r.RoomTypeName))
            .GroupBy(r => r.IdRoomType!.Value)
            .Select(g => new RoomBookingMapRoomTypeOption
            {
                Id = g.Key,
                Name = g.First().RoomTypeName!.Trim()
            })
            .OrderBy(t => t.Name, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    public RoomBookingMapGridLayout BuildTileGridLayout(DashboardMiniRoomStatus filtered)
    {
        ArgumentNullException.ThrowIfNull(filtered);

        const int labelColW = 88;
        const int cellW = 86;
        const int cellH = 118;
        const int minTotalW = 880;
        const int minTotalH = 120;

        var rowCount = Math.Max(1, filtered.FloorRowLabels.Count);
        if (filtered.FloorRowLabels.Count == 0 && filtered.Rooms.Count > 0)
            rowCount = filtered.Rooms.Max(r => r.GridRow) + 1;

        var roomColCount = 1;
        if (filtered.Rooms.Count > 0)
            roomColCount = Math.Max(1, filtered.Rooms.Max(r => r.GridCol) + 1);

        var cellsInGrid = filtered.Rooms
            .Where(c => c.GridRow >= 0 && c.GridRow < rowCount && c.GridCol >= 0 && c.GridCol < roomColCount)
            .ToList();

        return new RoomBookingMapGridLayout
        {
            RowCount = rowCount,
            ColumnCount = roomColCount,
            HasFloorLabelColumn = true,
            FloorLabelColumnWidth = labelColW,
            MinimumWidth = Math.Max(minTotalW, labelColW + roomColCount * cellW),
            MinimumHeight = Math.Max(minTotalH, rowCount * cellH),
            CellsInGrid = cellsInGrid
        };
    }
}
