using Catcheap.Models.ToStringConverter_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;
using Microsoft.Maui.Platform;

namespace Catcheap.Views;

public partial class DisplayVehiclePage : ContentPage
{
    readonly Car car;
    readonly CarString carString;
    readonly CarLoaderSaver carLoaderSaver;

    readonly VehicleScooter scooter;
    readonly ElectricScooterString scooterString;
    readonly ScooterLoaderSaver scooterLoaderSaver;


    readonly List<Vehicle> vehicleList;
    public DisplayVehiclePage(Car car, CarLoaderSaver carLoaderSaver, ScooterLoaderSaver scooterLoaderSaver, VehicleScooter scooter, List<Vehicle> vehiclesList, CarString carString,
                              ElectricScooterString scooterString)
	{
        this.car = car;
        this.carLoaderSaver = carLoaderSaver;
        this.scooterLoaderSaver = scooterLoaderSaver;
        this.scooter = scooter;
        this.vehicleList = vehiclesList;
        this.carString = carString;
        this.scooterString = scooterString;

        InitializeComponent();
        vehicleList.Add(car);
        vehicleList.Add(scooter);
    }

    private async void CarButtonClicked(object sender, EventArgs e)
	{

        System.Diagnostics.Debug.WriteLine("CAR BUTTON CLICKED");
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if(vehicle is Car car)
            {
                await CarLoaderSaver.Load(car);
                Placeholder.Text += carString.ToString(car) + '\n';
            }
        }
	}

    private void ScooterButtonClicked(object sender, EventArgs e)
    {
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if (vehicle is VehicleScooter scooter)
            {
                scooterLoaderSaver.Load(scooter);

                Placeholder.Text += scooterString.ToString(scooter) + '\n'; 
            }
        }
    }

    private async void AllButtonClicked(object sender, EventArgs e)
    {
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if (vehicle is Car car)
            {
                await CarLoaderSaver.Load(car);
                Placeholder.Text += carString.ToString(car) + '\n';
            }
            else if (vehicle is VehicleScooter scooter)
            {
                scooterLoaderSaver.Load(scooter);
                Placeholder.Text += scooterString.ToString(scooter) + '\n';
            }
        }
    }


}