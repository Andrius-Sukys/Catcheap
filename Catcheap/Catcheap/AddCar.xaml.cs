namespace Catcheap;

public partial class AddCar : ContentPage
{
	public AddCar()
	{
		InitializeComponent();
	}

    private void CarNameEntryTextChanged(object sender, EventArgs e) {; }

    private void CarBatterySizeEntryTextChanged(object sender, EventArgs e) {; }

    private void CarconsumtionEntryTextChanged(object sender, EventArgs e) {; }

    private void ChargingPowerEntryTextChanged(object sender, EventArgs e) {; }

    private void SaveClicked(object sender, EventArgs e)
    {

        TestShowNameValue.Text = CarNameEntry.Text + " " + CarBatterySizeEntry.Text +  " kWh " + CarconsumtionEntry.Text + " kWh " + ChargingPowerEntry.Text + "kW";

    }

    private async void BackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}