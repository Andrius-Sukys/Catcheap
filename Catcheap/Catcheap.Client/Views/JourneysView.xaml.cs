using Catcheap.Client.ViewModels;

namespace Catcheap.Client.Views;

public partial class JourneysView : ContentPage
{
	public JourneysView()
	{
		InitializeComponent();
		BindingContext = new JourneysViewModel();
	}
}