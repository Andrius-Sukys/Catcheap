using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace Catcheap.Models.ToStringConverter_Classes;

public class ElectricScooterString : VehicleString
{
    public string WeightPattern = "Weight: ";
    public string WeightCapacityPattern = "Weight capacity: ";
    public string WeightRider = "Rider's weight: ";
    public string AverageSpeed = "Average speed: ";
    public string TopSpeed = "Top speed: ";

    public string ToString(VehicleScooter scooter)
    {
        return ManufacturerPattern + scooter.Manufacturer + '\n' +
               ModelPattern + scooter.Model + '\n' +
               ExpectedRangePattern + scooter.ExpectedRange + " km\n" +
               BatteryCapacityPattern + scooter.BatteryCapacity + " kWh\n" +
               ConsumptionPattern + scooter.Consumption + " kWh/100 km\n" +
               BatteryLevelPattern + scooter.BatteryLevel + " %\n" +
               WeightPattern + scooter.Weight + " kg\n" +
               WeightCapacityPattern + scooter.WeightCapacity + " kg\n" +
               WeightRider + scooter.WeightRider + " kg\n";
    }
}