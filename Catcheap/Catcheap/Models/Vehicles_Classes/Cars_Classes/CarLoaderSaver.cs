using System.IO.Enumeration;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.FileIO_Classes.Interfaces;
using Catcheap.Models.Journeys_Classes;

namespace Catcheap.Models.Vehicles_Classes.Cars_Classes
{
    public class CarLoaderSaver 
    {
        private FileIO file;

        public CarLoaderSaver()
        {
        }

        public CarLoaderSaver(FileIO fileIO)
        {
            this.file = fileIO;
        }

        public async Task Load(Car car, string fileName = "carinfo.txt")
        {
            //string temp = file.ReadTextFile(fileName);

            //foreach (Match match in Regex.Matches(temp, @"^\b\d .*", RegexOptions.Multiline))
            //{
            //    int en = short.Parse(Regex.Match(match.Value, @"^\b\d").Value);

            //    switch (en)
            //    {
            //        case (int)CarPattern.Manufacturer:
            //            car.Manufacturer = Regex.Replace(match.Value, @"^\b\d ", "");
            //            break;
            //        case (int)CarPattern.Model:
            //            car.Model = Regex.Replace(match.Value, @"^\b\d ", "");
            //            break;
            //        case (int)CarPattern.Mileage:
            //            car.Mileage = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
            //            break;
            //        case (int)CarPattern.ExpectedRange:
            //            car.ExpectedRange = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
            //            break;
            //        case (int)CarPattern.BatteryCapacity:
            //            car.BatteryCapacity = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
            //            break;
            //        case (int)CarPattern.Consumption:
            //            car.Consumption = double.Parse(Regex.Replace(match.Value, @"^\b\d ", ""));
            //            break;
            //        case (int)CarPattern.BatteryLevel:
            //            car.BatteryLevel = Math.Round(double.Parse(Regex.Replace(match.Value, @"^\b\d ", "")), 2);
            //            break;
            //        default: break;
            //    }
            //}

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.0.2.2:7172/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Cars");
                if (response.IsSuccessStatusCode)
                {
                    List<Car> list = await response.Content.ReadAsAsync<List<Car>>();

                    if (list.Count > 0)
                    {
                        car.Manufacturer = list[0].Manufacturer;
                        car.Model = list[0].Model;
                        car.ExpectedRange = list[0].ExpectedRange;
                        car.BatteryCapacity = list[0].BatteryCapacity;
                        car.Consumption = list[0].Consumption;
                        car.BatteryLevel = list[0].BatteryLevel;
                        car.journeys = list[0].journeys;
                        car.Mileage = list[0].Mileage;
                    }
                    
                }
                else
                {
                    throw new Exception("Bad get");
                }
            }
        }

        public async Task Save(Car car, string fileName = "carinfo.txt")
        {
            //file.WriteTextToFile((int)CarPattern.Manufacturer + " " + car.Manufacturer + '\n' +
            //                     (int)CarPattern.Model + " " + car.Model + '\n' +
            //                     (int)CarPattern.Mileage + " " + car.Mileage + '\n' +
            //                     (int)CarPattern.ExpectedRange + " " + car.ExpectedRange + '\n' +
            //                     (int)CarPattern.BatteryCapacity + " " + car.BatteryCapacity + '\n' +
            //                     (int)CarPattern.Consumption + " " + car.Consumption + '\n' +
            //                     (int)CarPattern.BatteryLevel + " " + car.BatteryLevel + '\n', "carinfo.txt");
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://10.0.2.2:7172/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Cars");
                if (response.IsSuccessStatusCode)
                {
                    List<Car> list = await response.Content.ReadAsAsync<List<Car>>();

                    if (list.Count > 0)
                    {

                        car.VehicleId = list[0].VehicleId;
                        car.journeys.JourneysId = list[0].journeys.JourneysId;
                        car.journeys.CarVehicleId = list[0].VehicleId;
                        car.journeys.DistanceList = new List<Journey>();

                        HttpResponseMessage resp = await client.PutAsJsonAsync($"api/Cars/{car.VehicleId}", car);
                        if (resp.IsSuccessStatusCode) { }
                        else
                        {
                            throw new Exception(resp.ToString());
                        }

                    }
                    else
                    {
                        HttpResponseMessage resp = await client.PostAsJsonAsync("api/Cars", car);
                        if (resp.IsSuccessStatusCode) { }
                        else
                        {
                            throw new Exception("Bad post");
                        }
                    }
                }
                else
                {
                    throw new Exception("Bad get");
                }
            }

        }

    }
}