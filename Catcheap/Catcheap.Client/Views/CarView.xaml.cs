using Catcheap.Client.ViewModels;

namespace Catcheap.Client.Views;

public partial class CarView : ContentPage
{
	public CarView()
	{
		InitializeComponent();
        BindingContext = new CarViewModel();
		
    }
}