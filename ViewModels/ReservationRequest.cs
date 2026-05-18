using System;

namespace HotelManagement.ViewModels;

public sealed class ReservationRequest
{
    public int RoomId { get; init; }
    public string FullName { get; init; } = "";
    public string CitizenId { get; init; } = "";
    public string Phone { get; init; } = "";
    public DateTime CheckIn { get; init; }
    public DateTime CheckOut { get; init; }
    public int Adults { get; init; }
    public int Children { get; init; }
    public string? Note { get; init; }
}
