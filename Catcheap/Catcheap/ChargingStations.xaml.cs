namespace Catcheap;

public partial class ChargingStations : ContentPage
{
	public ChargingStations()
	{
		InitializeComponent();
	}

    ChargingStation chargingStation = new ChargingStation();

    private void LoadButtonClicked(object sender, EventArgs e)
	{
		chargingStation.getChargingStations();
		Placeholder.Text = chargingStation.displayChargingStations();
	}

	private void VilniusButtonClicked(object sender, EventArgs e)
	{
        chargingStation.getChargingStations();
        Placeholder.Text = chargingStation.FilterQueryVilnius();
	}

	private void KaunasButtonClicked(object sender, EventArgs e)
	{
        chargingStation.getChargingStations();
        Placeholder.Text = chargingStation.FilterQueryKaunas();
    }

	private void KlaipedaButtonClicked(object sender, EventArgs e)
	{
        chargingStation.getChargingStations();
        Placeholder.Text = chargingStation.FilterQueryKlaipeda();
    }
}