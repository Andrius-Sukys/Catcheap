using Catcheap.API.Models.CarModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap.API.Models.ScooterModels;

public class ScooterCharge : IComparable<ScooterCharge>
{
    public int Id { get; set; }

    public double ChargingPower { get; set; }

    public DateTime StartOfCharge { get; set; }

    public DateTime EndOfCharge { get; set; }

    public double ChargingPrice { get; set; }

    public Scooter Scooter { get; set; } = null!;

    public int CompareTo(ScooterCharge? other)
    {
        return StartOfCharge.CompareTo(other.StartOfCharge);
    }

}
