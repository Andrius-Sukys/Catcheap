using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap_API.DTO;

public class CarDTO : VehicleDTO
{
    public int YearOfManufacture { get; set; }

    public int EngineHorsePowers { get; set; }

    [Column(TypeName = "date")]
    public DateTime MOTExpiry { get; set; }

    public double Mileage { get; set; }
}
