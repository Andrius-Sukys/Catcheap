using Catcheap.Client.ViewModels;

namespace Catcheap.Client.Views;

public partial class AddJourneyView : ContentPage
{
	public AddJourneyView()
	{
		InitializeComponent();
		BindingContext = new AddCarJourneyViewModel();
	}
}