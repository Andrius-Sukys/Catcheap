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

        Price price = new Price();

        Placeholder.Text = price.getPriceString();

    }
}