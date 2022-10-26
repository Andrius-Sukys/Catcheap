using Catcheap.ViewModel;

namespace Catcheap.Views;

public partial class Charges : ContentPage
{
	public Charges(ChargeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}