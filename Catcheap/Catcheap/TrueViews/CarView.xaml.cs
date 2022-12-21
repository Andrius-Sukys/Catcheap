using Catcheap.ViewModels;

namespace Catcheap.TrueViews;

public partial class CarView : ContentPage
{
	public CarView(CarViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}