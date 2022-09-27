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

    private void CarconsumtionEntryTextChanged(object sender, EventArgs e) {; }

    private void ChargingPowerEntryTextChanged(object sender, EventArgs e) {; }

    private void SaveClicked(object sender, EventArgs e)
    {

        fileIO.WirteTextToFile(CarNameEntry.Text + " " + CarBatterySizeEntry.Text + " kWh " + CarconsumtionEntry.Text + " kWh " + ChargingPowerEntry.Text + "kW", "carinfo.txt");

    }

    public void ReadClicked(object sender, EventArgs e)
    {
        TestShowNameValue.Text = fileIO.ReadTextFile("carinfo.txt");
    }

    private async void BackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}