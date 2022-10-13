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
        return ManufacturerPattern + vehicle.manufacturer + '\n' +
               ModelPattern + vehicle.model + '\n' +
               ExpectedRangePattern + vehicle.expectedRange + " km\n" +
               BatteryCapacityPattern + vehicle.batteryCapacity + " kWh\n" +
               ConsumptionPattern + vehicle.consumption + " kWh/100 km\n" +
               BatteryLevelPattern + vehicle.batteryLevel + " %\n";
    }
}

