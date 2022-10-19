using Catcheap.Models.Vehicles_Classes;

namespace Catcheap.Models.ToStringConverter_Classes;

public class VehicleString
{
    public string ManufacturerPattern = "Manufacturer: ";
    public string ModelPattern = "Model: ";
    public string ExpectedRangePattern = "Expected range: ";
    public string BatteryCapacityPattern = "Battery size: ";
    public string ConsumptionPattern = "Consumption rate: ";
    public string BatteryLevelPattern = "Battery level: ";

    public string ToString(Vehicle vehicle)
    {
        return ManufacturerPattern + vehicle.Manufacturer + '\n' +
               ModelPattern + vehicle.Model + '\n' +
               ExpectedRangePattern + vehicle.ExpectedRange + " km\n" +
               BatteryCapacityPattern + vehicle.BatteryCapacity + " kWh\n" +
               ConsumptionPattern + vehicle.Consumption + " kWh/100 km\n" +
               BatteryLevelPattern + vehicle.BatteryLevel + " %\n";
    }
}