using Catcheap.Client.ViewModels;
using Catcheap.Client.Models;

namespace Catcheap.Client.Views;

[QueryProperty("CarToDisplay", "car")]
public partial class AddCarView : ContentPage
{
	AddCarViewModel viewModel;
	public AddCarView()
	{
		InitializeComponent();
		viewModel = new AddCarViewModel();
		BindingContext = viewModel;
	}

	Car _carToDisplay;
	public Car CarToDisplay
	{
		get => _carToDisplay;
		set
		{
			if (_carToDisplay == value)
				return;

			_carToDisplay = value;

			viewModel.Id = _carToDisplay.Id;
			viewModel.Manufacturer = _carToDisplay.Manufacturer;
			viewModel.Model = _carToDisplay.Model;
			viewModel.Numberplate = _carToDisplay.Numberplate;
			viewModel.YearOfManufacture = _carToDisplay.YearOfManufacture;
			viewModel.MOTExpiry = DateTime.Now;
			viewModel.ExpectedRange = _carToDisplay.ExpectedRange;
			viewModel.BatteryCapacity = _carToDisplay.BatteryCapacity;
			viewModel.Consumption = _carToDisplay.Consumption;
			viewModel.BatteryLevel = _carToDisplay.BatteryLevel;
			viewModel.Mileage = _carToDisplay.Mileage;

        }
	}
}