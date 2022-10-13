using Catcheap.Models.ToStringConverter_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace Catcheap.Views;

public partial class DisplayScooters : ContentPage
{
    VehicleScooter scooter = new VehicleScooter();
    ElectricScooterString scooterString = new ElectricScooterString();
    ScooterLoaderSaver scooterLoaderSaver = new ScooterLoaderSaver();

    public DisplayScooters()
	{
        InitializeComponent();
    }

    private void ReloadButtonClicked(object sender, EventArgs e)
    {
        scooterLoaderSaver.Load(scooter);
        Placeholder.Text = scooterString.ToString(scooter);
    }
}