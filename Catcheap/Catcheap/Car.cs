using System.Text.RegularExpressions;

namespace Catcheap
{
    public class Car
    {
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public double Mileage { get; set; }

        public double ExpectedRange { get; set; }

        public double BatteryCapacity { get; set; }

        public double Consumption { get; set; }

        public double BatteryLevel { get; set; }

        private string ManufacturerPattern = "Manufacturer: ";
        private string ModelPattern = "Model: ";
        private string MileagePattern = "Mileage: ";
        private string ExpectedRangePattern = "Expected range: ";
        private string BatteryCapacityPattern = "Battery size: ";
        private string ConsumptionPattern = "Consumption rate: ";
        private string BatteryLevelPattern = "Battery level: ";

        Journeys journeys = new Journeys();

        public Journeys GetJourneys()
        {
            return journeys;
        }

        public void SetAll(string Manufacturer, string Model, string Mileage,
                           string BatteryCapacity, string Consumption, string BatteryLevel)
        {
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.Mileage = Double.Parse(Mileage);
            this.BatteryCapacity = Double.Parse(BatteryCapacity);
            this.Consumption = Double.Parse(Consumption);
            this.BatteryLevel = Double.Parse(BatteryLevel);
            this.ExpectedRange = Math.Round(Double.Parse(BatteryCapacity) / Double.Parse(Consumption) * 100, 2);
            if (this.ExpectedRange < 0)
                this.ExpectedRange = 0;
        }

        public override string ToString() {

            return ManufacturerPattern + Manufacturer + '\n' +
                   ModelPattern + Model + '\n' +
                   MileagePattern + Mileage + " km\n" +
                   ExpectedRangePattern + ExpectedRange + " km\n" +
                   BatteryCapacityPattern + BatteryCapacity + " kWh\n" +
                   ConsumptionPattern + Consumption + " kWh/100 km\n" +
                   BatteryLevelPattern + BatteryLevel + " %\n";

        }

        public void UpdateCarPropertiesAfterJourney(double journeyDistance)
        {
            Mileage += journeyDistance;
            BatteryLevel -= ((journeyDistance / 100 * Consumption) / BatteryCapacity) * 100;
            if(BatteryLevel < 0)
                BatteryLevel = 0;
            ExpectedRange -= journeyDistance;
        }

    }
}
