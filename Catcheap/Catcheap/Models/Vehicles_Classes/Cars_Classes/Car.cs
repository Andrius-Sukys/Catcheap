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
            expectedRange = CalculateExpectedRange();
        }


        public void UpdateCarFieldsAfterJourney(double journeyDistance)
        {
            DecreaseExpectedRange(journeyDistance);
            DecreaseBatteryLevel(journeyDistance);
            IncreaseMileage(journeyDistance);
        }

        public void IncreaseMileage(double journeyDistance)
        {
            mileage += journeyDistance;
        }

    }
}
