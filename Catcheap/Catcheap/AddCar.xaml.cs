namespace Catcheap;

public partial class AddCar : ContentPage
{
	public AddCar()
	{
		InitializeComponent();
	}

    private async void BackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }
}