namespace Catcheap.Views
{
	public partial class AddJourneyPage : ContentPage
	{
		public AddJourneyPage(AddJourneyPageViewModel addJourneyPageViewModel)
		{
			InitializeComponent();
			BindingContext = addJourneyPageViewModel;
		}
	}
}