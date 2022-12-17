namespace Catcheap_API.DTO;

public class VehicleDTO
{
    public int Id { get; set; }

    public string Manufacturer { get; set; } = null!;

    public string Model { get; set; } = null!;

    public double ExpectedRange { get; set; }

    public double BatteryCapacity { get; set; }

    public double Consumption { get; set; }

    public double BatteryLevel { get; set; }
}
