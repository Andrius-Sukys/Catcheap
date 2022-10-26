using Catcheap.Models.Journeys_Classes;

namespace Catcheap.Models.Vehicles_Classes;

public class Vehicle
{
    public string Manufacturer { get; set; }

    public string Model { get; set; }

    public double ExpectedRange { get; set; }

    public double BatteryCapacity { get; set; }

    public double Consumption { get; set; }

    public double BatteryLevel { get; set; }

    Lazy<Journeys> journeys = new Lazy<Journeys>();

    public Journeys GetJourneys()
    {
        return journeys.Value;
    }

    public void DecreaseExpectedRange(double JourneyDistance)
    {
        ExpectedRange -= JourneyDistance;
        if(ExpectedRange < 0)
            ExpectedRange = 0;
    }

    public void DecreaseBatteryLevel(double JourneyDistance, double Consumption, double BatteryCapacity, double AdditionalConsumption = 1)
    {
        BatteryLevel -= JourneyDistance / 100 * (Consumption * AdditionalConsumption) / BatteryCapacity * 100;
        if (BatteryLevel < 0)
            BatteryLevel = 0;
    }

    public void IncreaseBatteryLevel(double ChargedKWh)
    {
        BatteryLevel += BatteryLevel + ChargedKWh / BatteryCapacity * 100;
        if (BatteryLevel > 100)
            BatteryLevel = 100;
    }

    public void UpdateFieldsAfterJourney(double JourneyDistance, double AdditionalConsumption = 1)
    {
        DecreaseExpectedRange(JourneyDistance);
        DecreaseBatteryLevel(JourneyDistance, Consumption, BatteryCapacity, AdditionalConsumption);
    }

    public void UpdateFieldsAfterCharging(double ChargedKWh)
    {
        IncreaseBatteryLevel(ChargedKWh);
        CalculateExpectedRange();
    }

    public double CalculateExpectedRange()
    {
        if (Consumption != 0)
            ExpectedRange = Math.Round(BatteryCapacity * BatteryLevel * 0.01 / Consumption * 100, 2);
        else
            return 0;
        if (ExpectedRange > 0)
            return ExpectedRange;
        else
            return 0;
    }
}