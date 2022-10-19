using Catcheap.Models.Price_Classes;

namespace Catcheap.Views;

public partial class PricePage : ContentPage
{
	public PricePage()
	{
		InitializeComponent();
	}

    private void LoadCurrentPriceButtonClicked(object sender, EventArgs e)
	{
        Price price = new Price();

        Placeholder.Text = price.getCurrentPrice().ToString() + "€/kWh";
    }

    private void LoadCheapestPriceButtonClicked(object sender, EventArgs e)
    {
        Price price = new Price();

        Placeholder.Text = price.GetCheapestPriceAndHourString();
    }

}