using System.Text.RegularExpressions;

namespace Catcheap.Models.Vehicles_Classes.Cars_Classes
{
    public class Car : Vehicle
    {
        public double mileage { get; set; }

        public void SetAll(string Manufacturer, string Model, string Mileage,
                           string BatteryCapacity, string Consumption, string BatteryLevel)
        {
            manufacturer = Manufacturer;
            model = Model;
            mileage = double.Parse(Mileage);
            batteryCapacity = double.Parse(BatteryCapacity);
            consumption = double.Parse(Consumption);
            batteryLevel = double.Parse(BatteryLevel);
            expectedRange = CalculateExpectedRange(batteryLevel, batteryCapacity, consumption);
        }


        public void UpdateCarFieldsAfterJourney(double journeyDistance, double batteryLevel, double batteryCapacity, double consumption)
        {
            DecreaseExpectedRange(journeyDistance);
            DecreaseBatteryLevel(journeyDistance, batteryLevel, batteryCapacity, consumption);
            IncreaseMileage(journeyDistance);
        }

        public void IncreaseMileage(double journeyDistance)
        {
            mileage += journeyDistance;
        }

    }
}
