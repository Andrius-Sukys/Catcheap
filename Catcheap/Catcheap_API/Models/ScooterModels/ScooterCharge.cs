using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap_API.Models.ScooterModels;

public class ScooterCharge
{
    public int Id { get; set; }

    public double ChargingPower { get; set; }

    public DateTime StartOfCharge { get; set; }

    public DateTime EndOfCharge { get; set; }

    public double ChargingPrice { get; set; }

    public Scooter Scooter { get; set; } = null!;

}
