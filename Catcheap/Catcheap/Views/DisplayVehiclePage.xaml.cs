using Catcheap.Models.ToStringConverter_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;
using Microsoft.Maui.Platform;

namespace Catcheap.Views;

public partial class DisplayVehiclePage : ContentPage
{
    Car car;
	CarString carString = new CarString();
	CarLoaderSaver carLoaderSaver= new CarLoaderSaver();

    VehicleScooter scooter = new VehicleScooter();
    ElectricScooterString scooterString = new ElectricScooterString();
    ScooterLoaderSaver scooterLoaderSaver = new ScooterLoaderSaver();
   

    List<Vehicle> vehicleList = new List<Vehicle>();
    public DisplayVehiclePage(Car car)
	{
        this.car = car;

        InitializeComponent();
        vehicleList.Add(car);
        vehicleList.Add(scooter);
    }

    private void CarButtonClicked(object sender, EventArgs e)
	{
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if(vehicle is Car)
            {
                carLoaderSaver.Load((Car)vehicle);
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

    private void AllButtonClicked(object sender, EventArgs e)
    {
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if (vehicle is Car)
            {
                carLoaderSaver.Load((Car)vehicle);
                Placeholder.Text += carString.ToString((Car)vehicle) + '\n';
            }else if (vehicle is VehicleScooter)
            {
                scooterLoaderSaver.Load((VehicleScooter)vehicle);
                Placeholder.Text += scooterString.ToString((VehicleScooter)vehicle) + '\n';
            }
        }
    }


}