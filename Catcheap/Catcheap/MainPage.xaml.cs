namespace Catcheap;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    private async void AddCarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//AddCar");
    }
}

