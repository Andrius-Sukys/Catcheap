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
        return ManufacturerPattern + scooter.manufacturer + '\n' +
               ModelPattern + scooter.model + '\n' +
               ExpectedRangePattern + scooter.expectedRange + " km\n" +
               BatteryCapacityPattern + scooter.batteryCapacity + " kWh\n" +
               ConsumptionPattern + scooter.consumption + " kWh/100 km\n" +
               BatteryLevelPattern + scooter.batteryLevel + " %\n" +
               WeightPattern + scooter.weight + " kg\n" +
               WeightCapacityPattern + scooter.weightCapacity + " kg\n" +
               WeightRider + scooter.weightRider + " kg\n" +
               AverageSpeed + scooter.averageSpeed + " km/h\n" +
               TopSpeed + scooter.topSpeed + " km/h\n";
    }
}