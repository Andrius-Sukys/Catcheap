namespace Catcheap;

public partial class AddCar : ContentPage
{
	public AddCar()
	{
		InitializeComponent();
	}

    FileIO fileIO = new FileIO();

    Car car = new Car();

    private void CarNameEntryTextChanged(object sender, EventArgs e) {; }

    private void CarBatterySizeEntryTextChanged(object sender, EventArgs e) {; }

    private void CarConsumptionEntryTextChanged(object sender, EventArgs e) {; }

    private void ChargingPowerEntryTextChanged(object sender, EventArgs e) {; }

    private void SaveClicked(object sender, EventArgs e)
    {

        car.SetAll(CarNameEntry.Text, CarBatterySizeEntry.Text, CarConsumptionEntry.Text, ChargingPowerEntry.Text);

        car.carDistance.addDistance(DateOnly.FromDateTime(DateTime.Today), 100);
        car.carDistance.addDistance(DateOnly.Parse("10/2/2021"), 15);

        car.Save();

        car.Load();

        CarSpecs.Text = car.ToString();

    }

    private async void CancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}