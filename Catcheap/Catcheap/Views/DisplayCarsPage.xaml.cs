namespace Catcheap.Views;

public partial class DisplayCarsPage : ContentPage
{
	Car car = new Car();
	CarLoaderSaver carLoaderSaver= new CarLoaderSaver();
	public DisplayCarsPage()
	{
		InitializeComponent();
	}

	private void ReloadButtonClicked(object sender, EventArgs e)
	{
		carLoaderSaver.Load(car);
		Placeholder.Text = car.ToString();
	}
}