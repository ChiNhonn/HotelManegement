using System;

namespace HotelManagement.ViewModels;

public sealed class BookingDetailsDto
{
    public int OrderId { get; init; }
    public int RoomId { get; init; }
    public string RoomName { get; init; } = "";
    public string? RoomTypeName { get; init; }
    public decimal NightlyPrice { get; init; }

    public string GuestName { get; init; } = "";
    public string CitizenId { get; init; } = "";
    public string Phone { get; init; } = "";

    public DateTime CheckIn { get; init; }
    public DateTime? CheckOut { get; init; }

    public int Adults { get; init; }
    public int Children { get; init; }
    public string? UserNote { get; init; }

    public int Nights { get; init; }
    public decimal ExpectedTotal { get; init; }

    public string? RawOrderNote { get; init; }
}

public sealed class ReservationUpdateRequest
{
    public int OrderId { get; init; }
    public string FullName { get; init; } = "";
    public string CitizenId { get; init; } = "";
    public string Phone { get; init; } = "";
    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public int Adults { get; init; }
    public int Children { get; init; }
    public string? Note { get; init; }
}
