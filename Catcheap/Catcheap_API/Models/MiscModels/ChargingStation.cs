using Microsoft.Identity.Client;

namespace Catcheap_API.Models.MiscModels;

public class ChargingStation
{
    public int Id { get; set; }

    public string Holder { get; set; } = null!;

    public string Street { get; set; } = null!;

    public short StreetNumber { get; set; }

    public string City { get; set; } = null!;
}
