using Catcheap.API.Models.MiscModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Catcheap.API.Models.CarModels;

public class CarCharge : IComparable<CarCharge>
{
    public int Id { get; set; }

    public double ChargingPower { get; set; }

    public DateTime StartOfCharge { get; set; }

    public DateTime EndOfCharge { get; set; }

    public double ChargingPrice { get; set; }

    [JsonIgnore]
    public Car Car { get; set; } = null!;

    public int CompareTo(CarCharge? other)
    {
        return StartOfCharge.CompareTo(other.StartOfCharge);
    }

}
