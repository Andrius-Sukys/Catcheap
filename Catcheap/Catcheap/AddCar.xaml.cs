namespace Catcheap;

public partial class AddCar : ContentPage
{
	public AddCar()
	{
		InitializeComponent();
	}

    FileIO fileIO = new FileIO();

    Car car = new Car();

    ValidateInput validateInput = new ValidateInput();

    private void SaveClicked(object sender, EventArgs e)
    {
        if(!String.IsNullOrEmpty(ManufacturerEntry.Text) &&
           !String.IsNullOrEmpty(ModelEntry.Text) &&
           !String.IsNullOrEmpty(MileageEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(MileageEntry.Text) &&
           !String.IsNullOrEmpty(BatteryCapacityEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(BatteryCapacityEntry.Text) &&
           !String.IsNullOrEmpty(ConsumptionEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(ConsumptionEntry.Text) && 
           !String.IsNullOrEmpty(BatteryLevelEntry.Text) && validateInput.ValidateInputAsAPositiveNumber(BatteryLevelEntry.Text))
        {
            Placeholder.Text = "Input successful!";

            car.SetAll(Manufacturer: ManufacturerEntry.Text, Model: ModelEntry.Text, Mileage: MileageEntry.Text,
                       BatteryCapacity: BatteryCapacityEntry.Text, Consumption: ConsumptionEntry.Text, BatteryLevel: BatteryLevelEntry.Text);

            car.Save();

            car.Load();

        }

        else
        {
            Placeholder.Text = "Invalid input!";
        }

    }

}