using Catcheap.Models.Vehicles_Classes.Cars_Classes;

namespace Catcheap.Models.ToStringConverter_Classes;

public class CarString : VehicleString
{
    public string MileagePattern = "Mileage: ";
    public string ToString(Car car)
    {
        return ManufacturerPattern + car.manufacturer + '\n' +
               ModelPattern + car.model + '\n' +
               MileagePattern + car.mileage + " km\n" +
               ExpectedRangePattern + car.expectedRange + " km\n" +
               BatteryCapacityPattern + car.batteryCapacity + " kWh\n" +
               ConsumptionPattern + car.consumption + " kWh/100 km\n" +
               BatteryLevelPattern + car.batteryLevel + " %\n";
    }
}