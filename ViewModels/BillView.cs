using System;

namespace HotelManagement.ViewModels;
public class BillView
{
    public int Id { get; set; }


    public string BillID { get; set; } = string.Empty;

    public string RoomName { get; set; } = string.Empty;

    public string CustomerName { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = string.Empty;
}