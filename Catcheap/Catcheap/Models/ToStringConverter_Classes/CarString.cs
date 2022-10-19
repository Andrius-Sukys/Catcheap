using Catcheap.Models.Vehicles_Classes.Cars_Classes;

namespace Catcheap.Models.ToStringConverter_Classes;

public class CarString : VehicleString
{
    public string MileagePattern = "Mileage: ";
    public string ToString(Car car)
    {
        return ManufacturerPattern + car.Manufacturer + '\n' +
               ModelPattern + car.Model + '\n' +
               MileagePattern + car.Mileage + " km\n" +
               ExpectedRangePattern + car.ExpectedRange + " km\n" +
               BatteryCapacityPattern + car.BatteryCapacity + " kWh\n" +
               ConsumptionPattern + car.Consumption + " kWh/100 km\n" +
               BatteryLevelPattern + car.BatteryLevel + " %\n";
    }
}