using Catcheap.Models.ChargingStations_Classes;

namespace Catcheap.Views;

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
        Placeholder.Text = chargingStation.FilterByCity("Vilnius");
	}

	private void KaunasButtonClicked(object sender, EventArgs e)
	{
        chargingStation.getChargingStations();
        Placeholder.Text = chargingStation.FilterByCity("Kaunas");
    }

	private void KlaipedaButtonClicked(object sender, EventArgs e)
	{
        chargingStation.getChargingStations();
        Placeholder.Text = chargingStation.FilterByCity("Klaipėda");
    }
}