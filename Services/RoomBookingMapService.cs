using System;
using System.Collections.Generic;
using System.Linq;
using HotelManagement.Helpers;
using HotelManagement.Interfaces;
using HotelManagement.ViewModels;

namespace HotelManagement.Services;

public sealed class RoomBookingMapService : IRoomBookingMapService
{
    private readonly IRoomBookingMapRepository _repo;

    public RoomBookingMapService(IRoomBookingMapRepository repo)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
    }

    public DashboardMiniRoomStatus GetMiniRoomStatusAsOf(DateTime asOfDate)
    {
        var day = asOfDate.Date;
        var guestByRoom = _repo.GetGuestStayMapForDate(day);
        var raw = _repo.GetActiveRoomsWithTypes();

        var withNum = raw
            .Select(r => new RoomGridSlot
            {
                Id = r.Id,
                Name = r.Name,
                Status = r.Status ?? "",
                IdFloor = r.IdFloor,
                IdRoomType = r.IdRoomType,
                TypeName = r.TypeName,
                NightlyPrice = r.NightlyPrice,
                Num = int.TryParse(r.Name?.Trim(), System.Globalization.NumberStyles.Integer,
                    System.Globalization.CultureInfo.InvariantCulture, out var n)
                    ? n
                    : 0
            })
            .Where(x => x.Num > 0)
            .ToList();

        var floorBases = withNum
            .Select(x => x.Num / 100)
            .Distinct()
            .OrderBy(f => f)
            .Take(3)
            .ToList();

        var floorRank = floorBases.Select((f, idx) => (f, idx)).ToDictionary(t => t.f, t => t.idx);
        var cells = new List<DashboardMiniRoomCell>();

        foreach (var fb in floorBases)
        {
            if (!floorRank.TryGetValue(fb, out var row))
                continue;

            var onFloor = withNum
                .Where(x => x.Num / 100 == fb)
                .OrderBy(x => x.Num)
                .ToList();

            for (var col = 0; col < onFloor.Count && col < 10; col++)
            {
                var x = onFloor[col];
                string? guest = null;
                int? activeOrderId = null;
                if (guestByRoom.TryGetValue(x.Id, out var stay))
                {
                    guest = stay.GuestName;
                    activeOrderId = stay.OrderId;
                }

                var phys = RoomStatusMap.ClassifyPhysicalKind(x.Status);

                var kind = phys switch
                {
                    RoomPhysicalStatusKind.Maintenance => RoomPhysicalStatusKind.Maintenance,
                    _ when guest != null || phys == RoomPhysicalStatusKind.Occupied => RoomPhysicalStatusKind
                        .Occupied,
                    _ => phys
                };

                cells.Add(new DashboardMiniRoomCell
                {
                    RoomId = x.Id,
                    Name = string.IsNullOrWhiteSpace(x.Name) ? $"#{x.Id}" : x.Name.Trim(),
                    RawStatus = x.Status ?? "",
                    Kind = kind,
                    GuestName = guest,
                    ActiveOrderId = activeOrderId,
                    IdRoomType = x.IdRoomType,
                    RoomTypeName = string.IsNullOrWhiteSpace(x.TypeName) ? null : x.TypeName.Trim(),
                    NightlyPrice = x.NightlyPrice,
                    GridRow = row,
                    GridCol = col
                });
            }
        }

        return new DashboardMiniRoomStatus
        {
            Rooms = cells,
            VacantCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Vacant),
            OccupiedCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Occupied),
            CleaningCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Cleaning),
            MaintenanceCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Maintenance),
            UnknownCount = cells.Count(c => c.Kind == RoomPhysicalStatusKind.Unknown)
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

        const int rowCount = 3;
        const int minCols = 11;
        const int cellW = 86;
        const int cellH = 118;
        const int minTotalW = 880;
        const int minTotalH = 276;

        var colCount = minCols;
        if (filtered.Rooms.Count > 0)
            colCount = Math.Max(minCols, filtered.Rooms.Max(r => r.GridCol) + 1);

        var cellsInGrid = filtered.Rooms
            .Where(c => c.GridRow >= 0 && c.GridRow < rowCount && c.GridCol >= 0 && c.GridCol < colCount)
            .ToList();

        return new RoomBookingMapGridLayout
        {
            RowCount = rowCount,
            ColumnCount = colCount,
            MinimumWidth = Math.Max(minTotalW, colCount * cellW),
            MinimumHeight = Math.Max(minTotalH, rowCount * cellH),
            CellsInGrid = cellsInGrid
        };
    }

    private sealed class RoomGridSlot
    {
        public int Id { get; init; }
        public string Name { get; init; } = "";
        public string Status { get; init; } = "";
        public int? IdFloor { get; init; }
        public int? IdRoomType { get; init; }
        public string? TypeName { get; init; }
        public decimal NightlyPrice { get; init; }
        public int Num { get; init; }
    }
}
