using Catcheap.Client;
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

    public static async Task Load(Car car)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine("INSIDE THE CARLOADERSAVER METHOD LOAD");
            HttpResponseMessage response = await ApiClient.client.GetAsync("api/Car");

            System.Diagnostics.Debug.WriteLine("AFTER THE RESPONSE");

            System.Diagnostics.Debug.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                List<Car> list = await response.Content.ReadAsAsync<List<Car>>();

                Console.WriteLine(list);

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
        catch (Exception)
        {
        }
    }

    public static async Task Save(Car car, string fileName = "carinfo.txt")
    {
        try
        { 
            HttpResponseMessage response = await ApiClient.client.GetAsync("api/Car");
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
                        HttpResponseMessage resp = await ApiClient.client.PutAsJsonAsync($"api/Car/{car.VehicleId}", car);
                        if (resp.IsSuccessStatusCode) { }
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    try
                    {
                        HttpResponseMessage resp = await ApiClient.client.PostAsJsonAsync("api/Car", car);
                        if (resp.IsSuccessStatusCode) { }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                throw new Exception("Bad get");
            }
        }
        catch (Exception)
        {
        }
    }

}