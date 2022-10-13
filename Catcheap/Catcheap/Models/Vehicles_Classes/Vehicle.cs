using Catcheap.Models.Journeys_Classes;

namespace Catcheap.Models.Vehicles_Classes;

public class Vehicle
{
    public string manufacturer { get; set; }

    public string model { get; set; }

    public double expectedRange { get; set; }

    public double batteryCapacity { get; set; }

    public double consumption { get; set; }

    public double batteryLevel { get; set; }

    Journeys journeys = new Journeys();

    public Journeys GetJourneys()
    {
        return journeys;
    }

    public void DecreaseExpectedRange(double journeyDistance)
    {
        if (expectedRange > journeyDistance)
            expectedRange -= journeyDistance;
        else
            expectedRange = 0;
    }

    public void DecreaseBatteryLevel(double journeyDistance, double batteryLevel, double batteryCapacity, double consumption)
    {
        batteryLevel -= journeyDistance / 100 * consumption / batteryCapacity * 100;
        if (batteryLevel < 0)
            batteryLevel = 0;
    }

    public void UpdateFieldsAfterJourney(double journeyDistance, double batteryLevel, double batteryCapacity, double consumption)
    {
        DecreaseExpectedRange(journeyDistance);
        DecreaseBatteryLevel(journeyDistance, batteryLevel, batteryCapacity, consumption);
    }

    public double CalculateExpectedRange(double batteryLevel, double batteryCapacity, double consumption)
    {
        expectedRange = Math.Round(batteryCapacity * (1 - batteryLevel * 0.01) / consumption * 100, 2);
        if (expectedRange > 0)
            return expectedRange;
        else
            return 0;
    }
}

