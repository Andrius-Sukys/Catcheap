using Catcheap.Models.Validation_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace Catcheap.Views;

public partial class AddElectricScooter : ContentPage
{
    readonly ScooterLoaderSaver scooterLS;
    readonly VehicleScooter scooter;

    public AddElectricScooter(ScooterLoaderSaver scooterLoaderSaver, VehicleScooter scooter)
	{
        this.scooterLS = scooterLoaderSaver;
        this.scooter = scooter;

		InitializeComponent(); 
	}

    private void SaveClicked(object sender, EventArgs e)
	{
        if (CheckTextFields())
        {
            Placeholder.Text = "Input successful!";

            scooter.SetAll(manufacturer: ManufacturerEntry.Text, model: ModelEntry.Text, batteryCapacity: BatteryCapacityEntry.Text,
                           consumption: ConsumptionEntry.Text, batteryLevel: BatteryLevelEntry.Text, weight: WeightEntry.Text,
                           weightCapacity: WeightCapacityEntry.Text, ridersWeight: RidersWeightEntry.Text, averageSpeed: AverageSpeedEntry.Text,
                           topSpeed: TopSpeedEntry.Text);

            scooterLS.Save(scooter);

            scooterLS.Load(scooter);
        }

        else
        {
            Placeholder.Text = "Invalid input!";
        }
    }

    public bool CheckTextFields()
    {
        return !String.IsNullOrEmpty(ManufacturerEntry.Text) &&
                !String.IsNullOrEmpty(ModelEntry.Text) &&
                !String.IsNullOrEmpty(BatteryCapacityEntry.Text) && (Double.Parse(BatteryCapacityEntry.Text) >= 0) &&
                !String.IsNullOrEmpty(ConsumptionEntry.Text) && (Double.Parse(ConsumptionEntry.Text) >= 0) &&
                !String.IsNullOrEmpty(BatteryLevelEntry.Text) && (Double.Parse(BatteryLevelEntry.Text) >= 0) && (Double.Parse(BatteryLevelEntry.Text) <= 100) &&
                !String.IsNullOrEmpty(WeightEntry.Text) && (Double.Parse(WeightEntry.Text) >= 0) &&
                !String.IsNullOrEmpty(WeightCapacityEntry.Text) && (Double.Parse(WeightCapacityEntry.Text) >= 0) &&
                !String.IsNullOrEmpty(RidersWeightEntry.Text) && (Double.Parse(RidersWeightEntry.Text) >= 0) &&
                !String.IsNullOrEmpty(AverageSpeedEntry.Text) && (Double.Parse(AverageSpeedEntry.Text) >= 0) &&
                !String.IsNullOrEmpty(TopSpeedEntry.Text) && (Double.Parse(TopSpeedEntry.Text) >= 0);
    }
}