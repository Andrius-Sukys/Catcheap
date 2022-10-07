namespace Catcheap.Views;

public partial class DisplayCarsPage : ContentPage
{
	Car car = new Car();
	public DisplayCarsPage()
	{
		InitializeComponent();
	}

	private void ReloadButtonClicked(object sender, EventArgs e)
	{
		car.Load();
		Placeholder.Text = car.ToString();
	}
}