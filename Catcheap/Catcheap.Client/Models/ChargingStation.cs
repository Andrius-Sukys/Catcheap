namespace Catcheap.Client.Models;

public class ChargingStation
{
    public int Id { get; set; }

    public string Holder { get; set; } = null!;

    public string Street { get; set; } = null!;

    public short StreetNumber { get; set; }

    public string City { get; set; } = null!;
}
