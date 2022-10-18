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
                        car.manufacturer = Regex.Replace(match.Value, @"^\b\d ", "");
                        break;
                    case (int)CarPattern.Model:
                        car.model = Regex.Replace(match.Value, @"^\b\d ", "");
                        break;
                    case (int)CarPattern.Mileage:
                        car.mileage = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                        break;
                    case (int)CarPattern.ExpectedRange:
                        car.expectedRange = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                        break;
                    case (int)CarPattern.BatteryCapacity:
                        car.batteryCapacity = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                        break;
                    case (int)CarPattern.Consumption:
                        car.consumption = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                        break;
                    case (int)CarPattern.BatteryLevel:
                        car.batteryLevel = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                        break;
                    default: break;
                }
            }

            JourneysLoaderSaver journeysLoaderSaver = new JourneysLoaderSaver();

            journeysLoaderSaver.Load(journeys: car.GetJourneys());
        }

        public void Save(Car car, string fileName = "carinfo.txt")
        {
            file.WriteTextToFile((int)CarPattern.Manufacturer + " " + car.manufacturer + '\n' +
                                 (int)CarPattern.Model + " " + car.model + '\n' +
                                 (int)CarPattern.Mileage + " " + car.mileage + '\n' +
                                 (int)CarPattern.ExpectedRange + " " + car.expectedRange + '\n' +
                                 (int)CarPattern.BatteryCapacity + " " + car.batteryCapacity + '\n' +
                                 (int)CarPattern.Consumption + " " + car.consumption + '\n' +
                                 (int)CarPattern.BatteryLevel + " " + car.batteryLevel + '\n', "carinfo.txt");
        }

    }
}