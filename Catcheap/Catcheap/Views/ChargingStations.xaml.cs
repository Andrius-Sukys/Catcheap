﻿using Catcheap.Models.ChargingStations_Classes;

namespace Catcheap.Views;

public partial class ChargingStations : ContentPage
{
	public ChargingStations()
	{
		InitializeComponent();
	}

	readonly Lazy<ChargingStation> chargingStation = new Lazy<ChargingStation>();

    private async void LoadButtonClicked(object sender, EventArgs e)
	{
		try
		{
            string test = "test";
            Convert.ToInt32(test);
            chargingStation.Value.GetChargingStations();
            Placeholder.Text = chargingStation.Value.DisplayChargingStations();
        }
		catch (Exception)
		{
            await Navigation.PushAsync(new ExceptionPage());
        }
		
	}

	private void VilniusButtonClicked(object sender, EventArgs e)
	{
		try
		{
            chargingStation.Value.GetChargingStations();
            Placeholder.Text = chargingStation.Value.FilterByCity("Vilnius");
        }
        catch (Exception)
        {
            Navigation.PushAsync(new ExceptionPage());
        }
    }

	private void KaunasButtonClicked(object sender, EventArgs e)
	{
		try
		{
            chargingStation.Value.GetChargingStations();
            Placeholder.Text = chargingStation.Value.FilterByCity("Kaunas");
        }
        catch (Exception)
        {
            Navigation.PushAsync(new ExceptionPage());
        }
    }

	private void KlaipedaButtonClicked(object sender, EventArgs e)
	{
		try
		{
            chargingStation.Value.GetChargingStations();
            Placeholder.Text = chargingStation.Value.FilterByCity("Klaipėda");
        }
        catch (Exception)
        {
            Navigation.PushAsync(new ExceptionPage());
        }
    }
}