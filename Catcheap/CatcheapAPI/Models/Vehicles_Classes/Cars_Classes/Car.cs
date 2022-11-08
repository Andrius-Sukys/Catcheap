namespace CatcheapAPI.Models.Vehicles_Classes.Cars_Classes
{
    public class Car : Vehicle
    {
        public double Mileage { get; set; }

        public void SetAll(string manufacturer, string model, string mileage,
                           string batteryCapacity, string consumption, string batteryLevel)
        {
            Manufacturer = manufacturer;
            Model = model;
            Mileage = double.Parse(mileage);
            BatteryCapacity = double.Parse(batteryCapacity);
            Consumption = double.Parse(consumption);
            BatteryLevel = double.Parse(batteryLevel);
            ExpectedRange = CalculateExpectedRange();
        }


        public void UpdateCarFieldsAfterJourney(double journeyDistance)
        {
            DecreaseExpectedRange(journeyDistance);
            DecreaseBatteryLevel(journeyDistance, Consumption, BatteryCapacity);
            IncreaseMileage(journeyDistance);
        }

        public void IncreaseMileage(double journeyDistance)
        {
            Mileage += journeyDistance;
        }

    }
}
