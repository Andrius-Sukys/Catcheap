using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap.API.Models.CarModels;

public class Car
{
    public int Id { get; set; }

    public string Manufacturer { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Numberplate { get; set; } = null!;

    public int YearOfManufacture { get; set; }

    public int EngineHorsePowers { get; set; }

    [Column(TypeName = "date")]
    public DateTime MOTExpiry { get; set; }

    public double ExpectedRange { get; set; }

    public double BatteryCapacity { get; set; }

    public double Consumption { get; set; }

    public double BatteryLevel { get; set; }

    public double Mileage { get; set; }

    [JsonIgnore]
    public ICollection<CarJourney> Journeys { get; set; } = null!;

    [JsonIgnore]
    public ICollection<CarCharge> Charges { get; set; } = null!;
}
