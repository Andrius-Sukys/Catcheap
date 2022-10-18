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

    public void DecreaseExpectedRange(double JourneyDistance)
    {
        expectedRange -= JourneyDistance;
        if(expectedRange < 0)
            expectedRange = 0;
    }

    public void DecreaseBatteryLevel(double JourneyDistance, double Consumption, double BatteryCapacity)
    {
        batteryLevel -= JourneyDistance / 100 * Consumption / BatteryCapacity * 100;
        if (batteryLevel < 0)
            batteryLevel = 0;
    }

    public void UpdateFieldsAfterJourney(double JourneyDistance)
    {
        DecreaseExpectedRange(JourneyDistance);
        DecreaseBatteryLevel(JourneyDistance, consumption, batteryCapacity);
    }

    public double CalculateExpectedRange()
    {
        expectedRange = Math.Round(batteryCapacity * batteryLevel / consumption, 2);
        if (expectedRange > 0)
            return expectedRange;
        else
            return 0;
    }
}