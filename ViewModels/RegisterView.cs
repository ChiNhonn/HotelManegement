namespace HotelManagement.ViewModels;

public sealed class RegisterView
{
    public string FullName { get; init; } = "";
    public string Username { get; init; } = "";
    public string Password { get; init; } = "";
    public string Phone { get; init; } = "";
    public string Email { get; init; } = "";
    public string CitizenId { get; init; } = "";
    public int IdBranch { get; init; }
}