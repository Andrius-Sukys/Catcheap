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
        vehicleList.Add(scooter);
    }

    private void CarButtonClicked(object sender, EventArgs e)
	{
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if(vehicle is Car car1)
            {
                carLoaderSaver.Load(car1);
                Placeholder.Text += carString.ToString(car1);
            }
        }
	}

    private void ScooterButtonClicked(object sender, EventArgs e)
    {
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if (vehicle is VehicleScooter scooter1)
            {
                scooterLoaderSaver.Load(scooter1);
                Placeholder.Text += scooterString.ToString(scooter1);
            }
        }
    }

    private void AllButtonClicked(object sender, EventArgs e)
    {
        Placeholder.Text = "";

        foreach (Vehicle vehicle in vehicleList)
        {
            if (vehicle is Car car1)
            {
                carLoaderSaver.Load(car1);
                Placeholder.Text += carString.ToString(car1) + "\n------------------------------\n";
            }else if (vehicle is VehicleScooter scooter1)
            {
                scooterLoaderSaver.Load(scooter1);
                Placeholder.Text += scooterString.ToString(scooter1) + "\n------------------------------\n";
            }
        }
    }


}