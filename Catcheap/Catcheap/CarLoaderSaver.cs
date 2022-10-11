using System.IO.Enumeration;
using System.Text.RegularExpressions;


namespace Catcheap
{
    internal class CarLoaderSaver : ILoader<Car>, ISaver<Car>
    {
        private FileIO file = new FileIO();

        enum Pattern : int
        {
            Manufacturer,
            Model,
            Mileage,
            ExpectedRange,
            BatteryCapacity,
            Consumption,
            BatteryLevel,
        }

        public void Load(Car car, String fileName = "carinfo.txt")
        {
            string temp = file.ReadTextFile(fileName);

            foreach (Match match in Regex.Matches(temp, @"\b\d \S*"))
            {
                int en = Int16.Parse(Regex.Match(match.Value, @"\b\d").Value);

                switch (en)
                {
                    case ((int)Pattern.Manufacturer): car.Manufacturer = Regex.Replace(match.Value, @"\b\d ", "");
                        break;
                    case ((int)Pattern.Model): car.Model = Regex.Replace(match.Value, @"\b\d ", "");
                        break;
                    case ((int)Pattern.Mileage): car.Mileage = Double.Parse(Regex.Replace(match.Value, @"\b\d ", ""));
                        break;
                    case ((int)Pattern.ExpectedRange): car.ExpectedRange = Math.Round(Double.Parse(Regex.Replace(match.Value, @"\b\d ", "")), 2);
                        break;
                    case ((int)Pattern.BatteryCapacity): car.BatteryCapacity = Double.Parse(Regex.Replace(match.Value, @"\b\d ", ""));
                        break;
                    case ((int)Pattern.Consumption): car.Consumption = Double.Parse(Regex.Replace(match.Value, @"\b\d ", ""));
                        break;
                    case ((int)Pattern.BatteryLevel): car.BatteryLevel = Math.Round(Double.Parse(Regex.Replace(match.Value, @"\b\d ", "")), 2);
                        break;
                    default: break;
                }
            }
        }

        public void Save(Car car, String fileName = "carinfo.txt")
        {
            file.WriteTextToFile(((int)Pattern.Manufacturer) + " " + car.Manufacturer + '\n' +
                                 ((int)Pattern.Model) + " " + car.Model + '\n' +
                                 ((int)Pattern.Mileage) + " " + car.Mileage + '\n' +
                                 ((int)Pattern.ExpectedRange) + " " + car.ExpectedRange + '\n' +
                                 ((int)Pattern.BatteryCapacity) + " " + car.BatteryCapacity + '\n' +
                                 ((int)Pattern.Consumption) + " " + car.Consumption + '\n' +
                                 ((int)Pattern.BatteryLevel) + " " + car.BatteryLevel + '\n', "carinfo.txt");
        }

    }
}
