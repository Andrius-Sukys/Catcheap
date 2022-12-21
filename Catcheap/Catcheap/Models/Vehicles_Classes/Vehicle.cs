using Catcheap.Models.EventArgs_Classes;
using Catcheap.Models.Journeys_Classes;
using Catcheap.Models.Notification_Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catcheap.Models.Vehicles_Classes;

public delegate void LowOnBatteryEventHandler(object sender, LowOnBatteryEventArgs e);

public class Vehicle
{
    public event LowOnBatteryEventHandler LowOnBattery;

    [Key]
    public int VehicleId { get; set; }
    public string Manufacturer { get; set; }

    public string Model { get; set; }

    public double ExpectedRange { get; set; }

    public double BatteryCapacity { get; set; }

    public double Consumption { get; set; }

    public double BatteryLevel { get; set; }

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
        if (BatteryLevel <= 20)
        {
            PushNotification notification = new PushNotification(this);
            OnLowOnBattery(new LowOnBatteryEventArgs(Math.Round(BatteryLevel, 2)));
        }
            
    }

    public void IncreaseBatteryLevel(double ChargedKWh)
    {
        BatteryLevel += ChargedKWh / BatteryCapacity * 100;
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

    protected virtual void OnLowOnBattery(LowOnBatteryEventArgs args)
    {
        LowOnBattery?.Invoke(this, args);
    }
}