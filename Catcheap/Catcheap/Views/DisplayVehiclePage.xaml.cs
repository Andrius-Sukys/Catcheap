using Catcheap.Models.ToStringConverter_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace Catcheap.Views;

public partial class DisplayVehiclePage : ContentPage
{
	Car car = new Car();
	CarString carString = new CarString();
	CarLoaderSaver carLoaderSaver= new CarLoaderSaver();

    VehicleScooter scooter = new VehicleScooter();
    ElectricScooterString scooterString = new ElectricScooterString();
    ScooterLoaderSaver scooterLoaderSaver = new ScooterLoaderSaver();

    List<Vehicle> vehicleList = new List<Vehicle>();
    public DisplayVehiclePage()
	{
		InitializeComponent();
        vehicleList.Add(car);
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
                Placeholder.Text += carString.ToString(vehicle) + '\n';
            }
        }
	}

    private void ScooterButtonClicked(object sender, EventArgs e)
    {
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if (vehicle is VehicleScooter)
            {
                scooterLoaderSaver.Load((VehicleScooter)vehicle);
                Placeholder.Text += scooterString.ToString(vehicle) + '\n'; 
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
                Placeholder.Text += scooterString.ToString(vehicle) + '\n';
            }
        }
    }


}