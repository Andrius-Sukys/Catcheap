using Catcheap.Models.Price_Classes;

namespace Catcheap.Views;

public partial class TrendsPage : ContentPage
{
	public TrendsPage()
	{
		InitializeComponent();
	}

    private void LoadButtonClicked(object sender, EventArgs e)
    {

        Price price = Handler.MauiContext.Services.GetService<Price>();

        Placeholder.Text = price.GetPriceString();

    }
}