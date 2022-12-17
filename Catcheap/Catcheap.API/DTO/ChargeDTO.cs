using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap.API.DTO;

public class ChargeDTO
{
    public int Id { get; set; }

    public double ChargingPower { get; set; }

    public DateTime StartOfCharge { get; set; }

    public DateTime EndOfCharge { get; set; }

    public double ChargingPrice { get; set; }
}
