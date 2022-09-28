namespace Catcheap;

public partial class AddCar : ContentPage
{
	public AddCar()
	{
		InitializeComponent();
	}

    FileIO fileIO = new FileIO();

    private void CarNameEntryTextChanged(object sender, EventArgs e) {; }

    private void CarBatterySizeEntryTextChanged(object sender, EventArgs e) {; }

    private void CarConsumptionEntryTextChanged(object sender, EventArgs e) {; }

    private void ChargingPowerEntryTextChanged(object sender, EventArgs e) {; }

    private void SaveClicked(object sender, EventArgs e)
    {
        fileIO.WriteTextToFile("Name: " + CarNameEntry.Text + '\n' +
                               "Battery size: " + CarBatterySizeEntry.Text + " kWh" + '\n' + 
                               "Consumption rate: " + CarConsumptionEntry.Text + " kWh/100 km" + '\n' +
                               "Charging power: " + ChargingPowerEntry.Text + " kW" + '\n', "carinfo.txt");
        CarSpecs.Text = fileIO.ReadTextFile("carinfo.txt");
    }

    private async void CancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}