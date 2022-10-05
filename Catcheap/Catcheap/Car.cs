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

        private FileIO file = new FileIO();

        private string ManufacturerPattern = "Manufacturer: ";
        private string ModelPattern = "Model: ";
        private string MileagePattern = "Mileage: ";
        private string ExpectedRangePattern = "Expected range: ";
        private string BatteryCapacityPattern = "Battery size: ";
        private string ConsumptionPattern = "Consumption rate: ";
        private string BatteryLevelPattern = "Battery level: ";

        public void Load() {

            string temp = file.ReadTextFile("carinfo.txt");

            Manufacturer = Regex.Replace(Regex.Match(temp, @"\b" + ManufacturerPattern + @"\S*").Value, @"\b" + ManufacturerPattern, "");

            Model = Regex.Replace(Regex.Match(temp, @"\b" + ModelPattern + @"\S*").Value, @"\b" + ModelPattern, "");

            Mileage = Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + MileagePattern + @"\S*").Value, @"\b" + MileagePattern, ""));

            ExpectedRange = Math.Round(Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + ExpectedRangePattern + @"\S*").Value, @"\b" + ExpectedRangePattern, "")), 2);

            BatteryCapacity = Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + BatteryCapacityPattern + @"\S*").Value, @"\b" + BatteryCapacityPattern, ""));

            Consumption = Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + ConsumptionPattern + @"\S*").Value, @"\b" + ConsumptionPattern, ""));

            BatteryLevel = Math.Round(Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + BatteryLevelPattern + @"\S*").Value, @"\b" + BatteryLevelPattern, "")), 2);

        }

        public void Save() {

            file.WriteTextToFile(ManufacturerPattern + Manufacturer + '\n' +
                                 ModelPattern + Model + '\n' +
                                 MileagePattern + Mileage + '\n' +
                                 ExpectedRangePattern + ExpectedRange + '\n' +
                                 BatteryCapacityPattern + BatteryCapacity + '\n' +
                                 ConsumptionPattern + Consumption + '\n' +
                                 BatteryLevelPattern + BatteryLevel + '\n', "carinfo.txt");

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
            Load();
            Mileage += journeyDistance;
            BatteryLevel -= ((journeyDistance / 100 * Consumption) / BatteryCapacity) * 100;
            if(BatteryLevel < 0)
                BatteryLevel = 0;
            ExpectedRange -= journeyDistance;
            Save();
        }

    }
}
