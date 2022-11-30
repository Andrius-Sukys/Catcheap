using Catcheap.Client;
using Catcheap.Models.Exception_Classes;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Journeys_Classes;

namespace Catcheap.Models.Vehicles_Classes.Cars_Classes;

public class CarLoaderSaver 
{
    private FileIO file;

    public CarLoaderSaver()
    {
    }

    public CarLoaderSaver(FileIO fileIO)
    {
        file = fileIO;
    }

    public static async Task Load(Car car) //, string fileName = "carinfo.txt")
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

        //using (var client = new HttpClient())
        //{
        //    client.BaseAddress = new Uri("http://10.0.2.2:7172/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            HttpResponseMessage response = await ApiClient.client.GetAsync("api/Cars");

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
                    car.BatteryLevel = Math.Round(list[0].BatteryLevel, 2);
                    car.Journeys = list[0].Journeys;
                    car.Mileage = list[0].Mileage;
                }

            }
        }
        catch (Exception ex)
        {
            ExceptionLogger.LogException(ex);
        }
    }

    public static async Task Save(Car car, string fileName = "carinfo.txt")
    {
        //file.WriteTextToFile((int)CarPattern.Manufacturer + " " + car.Manufacturer + '\n' +
        //                     (int)CarPattern.Model + " " + car.Model + '\n' +
        //                     (int)CarPattern.Mileage + " " + car.Mileage + '\n' +
        //                     (int)CarPattern.ExpectedRange + " " + car.ExpectedRange + '\n' +
        //                     (int)CarPattern.BatteryCapacity + " " + car.BatteryCapacity + '\n' +
        //                     (int)CarPattern.Consumption + " " + car.Consumption + '\n' +
        //                     (int)CarPattern.BatteryLevel + " " + car.BatteryLevel + '\n', "carinfo.txt");
        //using (var client = new HttpClient())
        //{
        //    client.BaseAddress = new Uri("http://10.0.2.2:7172/");
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/json"));

        try
        { 
            HttpResponseMessage response = await ApiClient.client.GetAsync("api/Cars");
            if (response.IsSuccessStatusCode)
            {
                List<Car> list = await response.Content.ReadAsAsync<List<Car>>();

                if (list.Count > 0)
                {

                    car.VehicleId = list[0].VehicleId;
                    car.Journeys.JourneysId = list[0].Journeys.JourneysId;
                    car.Journeys.CarVehicleId = list[0].VehicleId;
                    car.Journeys.DistanceList = new List<Journey>();

                    try
                    {
                        HttpResponseMessage resp = await ApiClient.client.PutAsJsonAsync($"api/Cars/{car.VehicleId}", car);
                        if (resp.IsSuccessStatusCode) { }
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogger.LogException(ex);
                    }
                }
                else
                {
                    try
                    {
                        HttpResponseMessage resp = await ApiClient.client.PostAsJsonAsync("api/Cars", car);
                        if (resp.IsSuccessStatusCode) { }
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogger.LogException(ex);
                    }
                }
            }
            else
            {
                throw new Exception("Bad get");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogger.LogException(ex);
        }
    }

}