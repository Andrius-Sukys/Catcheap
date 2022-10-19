﻿using Catcheap.Models.Journeys_Classes;

namespace Catcheap.Models.Vehicles_Classes;

public class Vehicle
{
    public string Manufacturer { get; set; }

    public string Model { get; set; }

    public double ExpectedRange { get; set; }

    public double BatteryCapacity { get; set; }

    public double Consumption { get; set; }

    public double BatteryLevel { get; set; }

    Journeys journeys = new Journeys();

    public Journeys GetJourneys()
    {
        return journeys;
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

    public void UpdateFieldsAfterJourney(double JourneyDistance, double AdditionalConsumption = 1)
    {
        DecreaseExpectedRange(JourneyDistance);
        DecreaseBatteryLevel(JourneyDistance, Consumption, BatteryCapacity, AdditionalConsumption);
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