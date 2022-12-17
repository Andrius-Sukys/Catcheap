namespace Catcheap.API.Models.ScooterModels;

public class Scooter
{
    public int Id { get; set; }

    public string Manufacturer { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public int EnginePower { get; set; }

    public double ExpectedRange { get; set; }

    public double BatteryCapacity { get; set; }

    public double Consumption { get; set; }

    public double BatteryLevel { get; set; }

    public double Weight { get; set; }

    public double WeightCapacity { get; set; }

    public double WeightRider { get; set; }

    public double AverageSpeed { get; set; }

    public double TopSpeed { get; set; }

    public ICollection<ScooterJourney> Journeys { get; set; } = null!;

    public ICollection<ScooterCharge> Charges { get; set; } = null!;

}
