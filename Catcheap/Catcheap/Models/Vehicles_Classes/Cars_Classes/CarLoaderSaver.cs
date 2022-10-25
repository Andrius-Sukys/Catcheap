using System.IO.Enumeration;
using System.Text.RegularExpressions;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.FileIO_Classes.Interfaces;
using Catcheap.Models.Journeys_Classes;

namespace Catcheap.Models.Vehicles_Classes.Cars_Classes
{
    internal class CarLoaderSaver : ILoader<Car>, ISaver<Car>
    {
        private FileIO file = new FileIO();

        public void Load(Car car, string fileName = "carinfo.txt")
        {
            string temp = file.ReadTextFile(fileName);

            foreach (Match match in Regex.Matches(temp, @"^\b\d .*", RegexOptions.Multiline))
            {
                int en = short.Parse(Regex.Match(match.Value, @"^\b\d").Value);

                switch (en)
                {
                    case (int)CarPattern.Manufacturer:
                        car.Manufacturer = Regex.Replace(match.Value, @"^\b\d ", "");
                        break;
                    case (int)CarPattern.Model:
                        car.Model = Regex.Replace(match.Value, @"^\b\d ", "");
                        break;
                    case (int)CarPattern.Mileage:
                        car.Mileage = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                        break;
                    case (int)CarPattern.ExpectedRange:
                        car.ExpectedRange = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                        break;
                    case (int)CarPattern.BatteryCapacity:
                        car.BatteryCapacity = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                        break;
                    case (int)CarPattern.Consumption:
                        car.Consumption = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                        break;
                    case (int)CarPattern.BatteryLevel:
                        car.BatteryLevel = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                        break;
                    default: break;
                }
            }
        }

        public void Save(Car car, string fileName = "carinfo.txt")
        {
            file.WriteTextToFile((int)CarPattern.Manufacturer + " " + car.Manufacturer + '\n' +
                                 (int)CarPattern.Model + " " + car.Model + '\n' +
                                 (int)CarPattern.Mileage + " " + car.Mileage + '\n' +
                                 (int)CarPattern.ExpectedRange + " " + car.ExpectedRange + '\n' +
                                 (int)CarPattern.BatteryCapacity + " " + car.BatteryCapacity + '\n' +
                                 (int)CarPattern.Consumption + " " + car.Consumption + '\n' +
                                 (int)CarPattern.BatteryLevel + " " + car.BatteryLevel + '\n', "carinfo.txt");
        }

    }
}