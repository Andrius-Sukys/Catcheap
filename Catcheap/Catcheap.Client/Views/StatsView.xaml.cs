using Catcheap.Client.ViewModels;

namespace Catcheap.Client.Views;

public partial class StatsView : ContentPage
{
	public StatsView()
	{
		InitializeComponent();
		BindingContext = new StatsViewModel();
	}
}