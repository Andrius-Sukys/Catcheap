namespace Catcheap.Client.Views;

public partial class PriceTrends : ContentPage
{
	public PriceTrends()
	{
		InitializeComponent();
		BindingContext = new NordpoolPricesView();
	}
}