using Catcheap.Models.Validation_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace Catcheap.Views;

public partial class AddElectricScooter : ContentPage
{
	public AddElectricScooter()
	{
		InitializeComponent(); 
	}

    ValidateInput validateInput = new ValidateInput();
    VehicleScooter scooter = new VehicleScooter();
    ScooterLoaderSaver scooterLS = new ScooterLoaderSaver();

    private void SaveClicked(object sender, EventArgs e)
	{
        if (!String.IsNullOrEmpty(ManufacturerEntry.Text) &&
            !String.IsNullOrEmpty(ModelEntry.Text) &&
            !String.IsNullOrEmpty(BatteryCapacityEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(BatteryCapacityEntry.Text) &&
            !String.IsNullOrEmpty(ConsumptionEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(ConsumptionEntry.Text) &&
            !String.IsNullOrEmpty(BatteryLevelEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(BatteryLevelEntry.Text) &&
            !String.IsNullOrEmpty(WeightEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(WeightEntry.Text) &&
            !String.IsNullOrEmpty(WeightCapacityEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(WeightCapacityEntry.Text) &&
            !String.IsNullOrEmpty(RidersWeightEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(RidersWeightEntry.Text) &&
            !String.IsNullOrEmpty(AverageSpeedEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(AverageSpeedEntry.Text) &&
            !String.IsNullOrEmpty(TopSpeedEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(TopSpeedEntry.Text))
        {
            Placeholder.Text = "Input successful!";

            scooter.SetAll(Manufacturer: ManufacturerEntry.Text, Model: ModelEntry.Text, BatteryCapacity: BatteryCapacityEntry.Text,
                           Consumption: ConsumptionEntry.Text, BatteryLevel: BatteryLevelEntry.Text, Weight: WeightEntry.Text,
                           WeightCapacity: WeightCapacityEntry.Text, RidersWeight: RidersWeightEntry.Text, AverageSpeed: AverageSpeedEntry.Text,
                           TopSpeed: TopSpeedEntry.Text);

            scooterLS.Save(scooter);

            scooterLS.Load(scooter);
        }

        else
        {
            Placeholder.Text = "Invalid input!";
        }
    }
}