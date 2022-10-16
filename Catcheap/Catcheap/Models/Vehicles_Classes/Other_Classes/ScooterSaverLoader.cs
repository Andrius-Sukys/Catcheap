using Catcheap.Models.FileIO_Classes.Interfaces;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Journeys_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;
using System.Text.RegularExpressions;

namespace Catcheap.Models.Vehicles_Classes.Cars_Classes
{
    internal class ScooterLoaderSaver : ILoader<VehicleScooter>, ISaver<VehicleScooter>
    {
        private FileIO file = new FileIO();

        enum Pattern : int
        {
            Manufacturer,
            Model,
            BatteryCapacity,
            Consumption,
            BatteryLevel,
            ExpectedRange,
            Weight,
            WeightCapacity,
            WeightRider,
            AverageSpeed,
            TopSpeed
        }

        public void Load(VehicleScooter scooter, string fileName = "scooterinfo.txt")
        {
            string temp = file.ReadTextFile(fileName);

            if (temp != null) 
            {
                foreach (Match match in Regex.Matches(temp, @"^\b\d .*", RegexOptions.Multiline))
                {
                    int en = short.Parse(Regex.Match(match.Value, @"^\b\d").Value);

                    switch (en)
                    {
                        case (int)Pattern.Manufacturer:
                            scooter.manufacturer = Regex.Replace(match.Value, @"^\b\d ", "");
                            break;
                        case (int)Pattern.Model:
                            scooter.model = Regex.Replace(match.Value, @"^\b\d ", "");
                            break;

                        case (int)Pattern.BatteryCapacity:
                            scooter.batteryCapacity = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                            break;
                        case (int)Pattern.Consumption:
                            scooter.consumption = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                            break;
                        case (int)Pattern.BatteryLevel:
                            scooter.batteryLevel = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)Pattern.ExpectedRange:
                            scooter.expectedRange = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)Pattern.Weight:
                            scooter.weight = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)Pattern.WeightCapacity:
                            scooter.weightCapacity = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)Pattern.WeightRider:
                            scooter.weightRider = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)Pattern.AverageSpeed:
                            scooter.averageSpeed = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)Pattern.TopSpeed:
                            scooter.topSpeed = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        default: break;
                    }
                }
            }

            JourneysLoaderSaver journeysLoaderSaver = new JourneysLoaderSaver();

            journeysLoaderSaver.Load(journeys: scooter.GetJourneys());
        }

        public void Save(VehicleScooter scooter, string fileName = "scooterinfo.txt")
        {
            file.WriteTextToFile((int)Pattern.Manufacturer + " " + scooter.manufacturer + '\n' +
                                 (int)Pattern.Model + " " + scooter.model + '\n' +
                                 (int)Pattern.BatteryCapacity + " " + scooter.batteryCapacity + '\n' +
                                 (int)Pattern.Consumption + " " + scooter.consumption + '\n' +
                                 (int)Pattern.BatteryLevel + " " + scooter.batteryLevel + '\n' +
                                 (int)Pattern.ExpectedRange + " " + scooter.expectedRange + '\n' +
                                 (int)Pattern.Weight + " " + scooter.weight + '\n' +
                                 (int)Pattern.WeightCapacity + " " + scooter.batteryLevel + '\n' +
                                 (int)Pattern.WeightRider + " " + scooter.weightRider + '\n' +
                                 (int)Pattern.AverageSpeed + " " + scooter.averageSpeed + '\n' +
                                 (int)Pattern.TopSpeed + " " + scooter.topSpeed + '\n', "scooterinfo.txt");
        }

    }
}