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
                        case (int)ScooterPattern.Manufacturer:
                            scooter.Manufacturer = Regex.Replace(match.Value, @"^\b\d ", "");
                            break;
                        case (int)ScooterPattern.Model:
                            scooter.Model = Regex.Replace(match.Value, @"^\b\d ", "");
                            break;
                        case (int)ScooterPattern.BatteryCapacity:
                            scooter.BatteryCapacity = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                            break;
                        case (int)ScooterPattern.Consumption:
                            scooter.Consumption = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
                            break;
                        case (int)ScooterPattern.BatteryLevel:
                            scooter.BatteryLevel = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)ScooterPattern.ExpectedRange:
                            scooter.ExpectedRange = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)ScooterPattern.Weight:
                            scooter.Weight = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)ScooterPattern.WeightCapacity:
                            scooter.WeightCapacity = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)ScooterPattern.WeightRider:
                            scooter.WeightRider = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)ScooterPattern.AverageSpeed:
                            scooter.AverageSpeed = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
                            break;
                        case (int)ScooterPattern.TopSpeed:
                            scooter.TopSpeed = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
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

            file.WriteTextToFile((int)ScooterPattern.Manufacturer + " " + scooter.Manufacturer + '\n' +
                                 (int)ScooterPattern.Model + " " + scooter.Model + '\n' +
                                 (int)ScooterPattern.BatteryCapacity + " " + scooter.BatteryCapacity + '\n' +
                                 (int)ScooterPattern.Consumption + " " + scooter.Consumption + '\n' +
                                 (int)ScooterPattern.BatteryLevel + " " + scooter.BatteryLevel + '\n' +
                                 (int)ScooterPattern.ExpectedRange + " " + scooter.ExpectedRange + '\n' +
                                 (int)ScooterPattern.Weight + " " + scooter.Weight + '\n' +
                                 (int)ScooterPattern.WeightCapacity + " " + scooter.WeightCapacity + '\n' +
                                 (int)ScooterPattern.WeightRider + " " + scooter.WeightRider + '\n' +
                                 (int)ScooterPattern.AverageSpeed + " " + scooter.AverageSpeed + '\n' +
                                 (int)ScooterPattern.TopSpeed + " " + scooter.TopSpeed + '\n', fileName);
        }

    }
}