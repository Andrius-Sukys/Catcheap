using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap.API.Models.CarModels;

public class CarCharge
{
    public int Id { get; set; }

    public double ChargingPower { get; set; }

    public DateTime StartOfCharge { get; set; }

    public DateTime EndOfCharge { get; set; }

    public double ChargingPrice { get; set; }

    public Car Car { get; set; } = null!;

}
