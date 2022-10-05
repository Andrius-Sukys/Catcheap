namespace Catcheap
{
	public partial class AddJourneyPage : ContentPage
	{
		public AddJourneyPage()
		{
			InitializeComponent();
			BindingContext = new AddJourneyPageViewModel();
		}
	}
}