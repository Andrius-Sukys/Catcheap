using Catcheap.Client.ViewModels;

namespace Catcheap.Client.Views;

public partial class NordpoolPricesView : ContentPage
{
	public NordpoolPricesView()
	{
		InitializeComponent();
		BindingContext = new NordpoolPriceViewModel();
	}
}