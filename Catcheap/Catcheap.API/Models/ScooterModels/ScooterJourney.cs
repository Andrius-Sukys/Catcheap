using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap.API.Models.ScooterModels;

public class ScooterJourney
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public double Distance { get; set; }

    public string StartLocation { get; set; } = null!;

    public string EndLocation { get; set; } = null!;

    [JsonIgnore]
    public Scooter Scooter { get; set; } = null!;

}
