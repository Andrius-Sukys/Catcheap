using System.IO.Enumeration;
using System.Text.RegularExpressions;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.FileIO_Classes.Interfaces;


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


            if (temp != null)
            {
                foreach (Match match in Regex.Matches(temp, @"\b\d \S+"))
                {
                    int en = Int16.Parse(Regex.Match(match.Value, @"\b\d").Value);

                    switch (en)
                    {
                        case ((int)Pattern.Manufacturer):
                            car.manufacturer = Regex.Replace(match.Value, @"\b\d ", "");
                            break;
                        case ((int)Pattern.Model):
                            car.model = Regex.Replace(match.Value, @"\b\d ", "");
                            break;
                        case ((int)Pattern.Mileage):
                            car.mileage = Double.Parse(Regex.Replace(match.Value, @"\b\d ", ""));
                            break;
                        case ((int)Pattern.ExpectedRange):
                            car.expectedRange = Math.Round(Double.Parse(Regex.Replace(match.Value, @"\b\d ", "")), 2);
                            break;
                        case ((int)Pattern.BatteryCapacity):
                            car.batteryCapacity = Double.Parse(Regex.Replace(match.Value, @"\b\d ", ""));
                            break;
                        case ((int)Pattern.Consumption):
                            car.consumption = Double.Parse(Regex.Replace(match.Value, @"\b\d ", ""));
                            break;
                        case ((int)Pattern.BatteryLevel):
                            car.batteryLevel = Math.Round(Double.Parse(Regex.Replace(match.Value, @"\b\d ", "")), 2);
                            break;
                        default: break;
                    }
                }
            }

            JourneysLoaderSaver journeysLoaderSaver = new JourneysLoaderSaver();

            journeysLoaderSaver.Load(car.GetJourneys());
        }

        public void Save(Car car, String fileName = "carinfo.txt")
        {
            file.WriteTextToFile(((int)Pattern.Manufacturer) + " " + car.manufacturer + '\n' +
                                 ((int)Pattern.Model) + " " + car.model + '\n' +
                                 ((int)Pattern.Mileage) + " " + car.mileage + '\n' +
                                 ((int)Pattern.ExpectedRange) + " " + car.expectedRange + '\n' +
                                 ((int)Pattern.BatteryCapacity) + " " + car.batteryCapacity + '\n' +
                                 ((int)Pattern.Consumption) + " " + car.consumption + '\n' +
                                 ((int)Pattern.BatteryLevel) + " " + car.batteryLevel + '\n', "carinfo.txt");
        }

    }
}
