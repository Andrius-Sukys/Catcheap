using Catcheap.Client.ViewModels;

namespace Catcheap.Client.Views;

public partial class AddChargeView : ContentPage
{
	public AddChargeView()
	{
		InitializeComponent();
		BindingContext = new AddCarChargeViewModel();
	}
}