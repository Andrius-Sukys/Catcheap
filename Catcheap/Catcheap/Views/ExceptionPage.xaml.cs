namespace Catcheap.Views;

public partial class ExceptionPage : ContentPage
{
	public ExceptionPage()
	{
		InitializeComponent();
	}

	private void ExitButtonClicked(object sender, EventArgs e)
	{
        Application.Current.Quit();
    }
}