using System.IO.Enumeration;
using System.Text.RegularExpressions;


namespace Catcheap
{
    internal class CarLoaderSaver : ILoader<Car>, ISaver<Car>
    {
        private FileIO file = new FileIO();

        private string ManufacturerPattern = "Manufacturer: ";
        private string ModelPattern = "Model: ";
        private string MileagePattern = "Mileage: ";
        private string ExpectedRangePattern = "Expected range: ";
        private string BatteryCapacityPattern = "Battery size: ";
        private string ConsumptionPattern = "Consumption rate: ";
        private string BatteryLevelPattern = "Battery level: ";

        public void Load(Car car, String fileName = "carinfo.txt")
        {
            string temp = file.ReadTextFile(fileName);

            car.Manufacturer = Regex.Replace(Regex.Match(temp, @"\b" + ManufacturerPattern + @"\S*").Value, @"\b" + ManufacturerPattern, "");

            car.Model = Regex.Replace(Regex.Match(temp, @"\b" + ModelPattern + @"\S*").Value, @"\b" + ModelPattern, "");

            car.Mileage = Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + MileagePattern + @"\S*").Value, @"\b" + MileagePattern, ""));

            car.ExpectedRange = Math.Round(Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + ExpectedRangePattern + @"\S*").Value, @"\b" + ExpectedRangePattern, "")), 2);

            car.BatteryCapacity = Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + BatteryCapacityPattern + @"\S*").Value, @"\b" + BatteryCapacityPattern, ""));

            car.Consumption = Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + ConsumptionPattern + @"\S*").Value, @"\b" + ConsumptionPattern, ""));

            car.BatteryLevel = Math.Round(Double.Parse(Regex.Replace(Regex.Match(temp, @"\b" + BatteryLevelPattern + @"\S*").Value, @"\b" + BatteryLevelPattern, "")), 2);
        }

        public void Save(Car car, String fileName = "carinfo.txt")
        {
            file.WriteTextToFile(ManufacturerPattern + car.Manufacturer + '\n' +
                                 ModelPattern + car.Model + '\n' +
                                 MileagePattern + car.Mileage + '\n' +
                                 ExpectedRangePattern + car.ExpectedRange + '\n' +
                                 BatteryCapacityPattern + car.BatteryCapacity + '\n' +
                                 ConsumptionPattern + car.Consumption + '\n' +
                                 BatteryLevelPattern + car.BatteryLevel + '\n', "carinfo.txt");
        }

    }
}
