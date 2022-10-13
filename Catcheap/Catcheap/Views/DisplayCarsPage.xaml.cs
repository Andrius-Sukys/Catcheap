using Catcheap.Models.ToStringConverter_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;

namespace Catcheap.Views;

public partial class DisplayCarsPage : ContentPage
{
	Car car = new Car();
	CarString carString = new CarString();
	CarLoaderSaver carLoaderSaver= new CarLoaderSaver();
	public DisplayCarsPage()
	{
		InitializeComponent();
	}

	private void ReloadButtonClicked(object sender, EventArgs e)
	{
		carLoaderSaver.Load(car);
		Placeholder.Text = carString.ToString(car);
	}
}