using System.Runtime.CompilerServices;

namespace Catcheap.Models.Vehicles_Classes.Other_Classes;

public class VehicleScooter : Vehicle
{
    public double weight { get; set; }

    public double weightCapacity { get; set; }

    public double weightRider { get; set; }

    public double averageSpeed { get; set; }

    public double topSpeed { get; set; }

    public void SetAll(string Manufacturer, string Model, string BatteryCapacity, string Consumption, string BatteryLevel,
                       string Weight, string WeightCapacity, string RidersWeight, string AverageSpeed, string TopSpeed)
    {
        manufacturer = Manufacturer;
        model = Model;
        batteryCapacity = double.Parse(BatteryCapacity);
        consumption = double.Parse(Consumption);
        batteryLevel = double.Parse(BatteryLevel);
        weight = Double.Parse(Weight);
        weightCapacity = Double.Parse(WeightCapacity);
        weightRider = Double.Parse(RidersWeight);
        averageSpeed = Double.Parse(AverageSpeed);
        topSpeed = Double.Parse(TopSpeed);

        expectedRange = CalculateExpectedRange(batteryCapacity, batteryLevel, consumption);//.AdjustExpectedRange(topSpeed, weight, weightCapacity, weightRider, averageSpeed);
    }

}

public static class ExtensionMethod
{
    public static double AdjustExpectedRange(this double range, double topSpeed, double weight,
                                                                 double weightCapacity, double weightRider, double averageSpeed)
    {
        if (topSpeed * 0.9 >= averageSpeed)
            range = range * 0.6;
        if ((weight + weightRider) * 0.9 > weightCapacity)
            range = range * 0.7;
        return range;
    }
}

