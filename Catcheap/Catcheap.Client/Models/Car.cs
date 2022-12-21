namespace Catcheap.Client.Models;

public class Car
{
    public int Id { get; set; }

    public string Manufacturer { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Numberplate { get; set; } = null!;

    public int YearOfManufacture { get; set; }

    public double ExpectedRange { get; set; }

    public double BatteryCapacity { get; set; }

    public double Consumption { get; set; }

    public double BatteryLevel { get; set; }

    public double Mileage { get; set; }
}
