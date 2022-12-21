using Catcheap.Client;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;

namespace Catcheap.ViewModels;

public class CarViewModel
{
    [ObservableProperty]
    public string Manufacturer;

    [ObservableProperty]
    public string Model;

    [ObservableProperty]
    public string Numberplate;

    [ObservableProperty]
    public int YearOfManufacture;

    [ObservableProperty]
    public int EngineHorsePowers;

    [ObservableProperty]
    public DateTime MOTExpiry;

    [ObservableProperty]
    public double ExpectedRange;

    [ObservableProperty]
    public double BatteryCapacity;

    [ObservableProperty]
    public double Consumption;

    [ObservableProperty]
    public double BatteryLevel;

    [ObservableProperty]
    public double Mileage;

    public CarViewModel()
    {
        getCarInfoAsync();


    }


    public async void getCarInfoAsync()
    {
        HttpResponseMessage response = await ApiClient.client.GetAsync("api/Car");

        string jsonResponse = await response.Content.ReadAsStringAsync();

        CarViewModel car = JsonConvert.DeserializeObject<CarViewModel>(jsonResponse);

        Console.WriteLine(car.ToString());
    }

}
