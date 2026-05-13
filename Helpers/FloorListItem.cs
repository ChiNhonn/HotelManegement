namespace HotelManagement.Helpers;

public sealed class FloorListItem
{
    public int? Id { get; }
    public string Display { get; }

    public FloorListItem(int? id, string display)
    {
        Id = id;
        Display = display;
    }

    public override string ToString() => Display;
}
