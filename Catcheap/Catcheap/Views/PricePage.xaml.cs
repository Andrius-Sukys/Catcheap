using Catcheap.Models.Price_Classes;

namespace Catcheap.Views;

public partial class PricePage : ContentPage
{
	public PricePage()
	{
		InitializeComponent();
	}

    private void LoadButtonClicked(object sender, EventArgs e)
	{

		Price price = new Price();

		PriceLabel.Text = price.getPriceString();

    }

    private void LoadCurrentPriceButtonClicked(object sender, EventArgs e)
	{
        Price price = new Price();

        CurrentPriceLabel.Text = price.getCurrentPrice().ToString();
    }
}