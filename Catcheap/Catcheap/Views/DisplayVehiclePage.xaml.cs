using Catcheap.Models.ToStringConverter_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;
using Microsoft.Maui.Platform;

namespace Catcheap.Views;

public partial class DisplayVehiclePage : ContentPage
{
    Car car;
	CarString carString;
	CarLoaderSaver carLoaderSaver;

    VehicleScooter scooter;
    ElectricScooterString scooterString;
    ScooterLoaderSaver scooterLoaderSaver;
   

    List<Vehicle> vehicleList;
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
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if(vehicle is Car)
            {
                await carLoaderSaver.Load((Car)vehicle);
                Placeholder.Text += carString.ToString((Car)vehicle) + '\n';
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
            if (vehicle is Car)
            {
                await carLoaderSaver.Load((Car)vehicle);
                Placeholder.Text += carString.ToString((Car)vehicle) + '\n';
            }else if (vehicle is VehicleScooter)
            {
                scooterLoaderSaver.Load((VehicleScooter)vehicle);
                Placeholder.Text += scooterString.ToString((VehicleScooter)vehicle) + '\n';
            }
        }
    }


}