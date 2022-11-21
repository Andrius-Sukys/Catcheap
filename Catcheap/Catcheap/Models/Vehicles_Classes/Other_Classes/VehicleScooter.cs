using System.Runtime.CompilerServices;

namespace Catcheap.Models.Vehicles_Classes.Other_Classes;

public class VehicleScooter : Vehicle
{
    public VehicleScooter()
    {
    }

    public VehicleScooter(Journeys journeys)
    {
        this.journeys = journeys;
    }
    public double Weight { get; set; }

    public double WeightCapacity { get; set; }

    public double WeightRider { get; set; }

    public double AverageSpeed { get; set; }

    public double TopSpeed { get; set; }

    public void SetAll(string manufacturer, string model, string batteryCapacity, string consumption, string batteryLevel,
                       string weight, string weightCapacity, string ridersWeight, string averageSpeed, string topSpeed)
    {
        Manufacturer = manufacturer;
        Model = model;
        BatteryCapacity = double.Parse(batteryCapacity);
        Consumption = double.Parse(consumption);
        BatteryLevel = double.Parse(batteryLevel);
        Weight = Double.Parse(weight);
        WeightCapacity = Double.Parse(weightCapacity);
        WeightRider = Double.Parse(ridersWeight);
        AverageSpeed = Double.Parse(averageSpeed);
        TopSpeed = Double.Parse(topSpeed);
        ExpectedRange = CalculateExpectedRange().AdjustExpectedRange(TopSpeed, Weight, WeightCapacity, WeightRider, AverageSpeed);
    }

}