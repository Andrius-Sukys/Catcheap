using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Validation_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;

namespace Catcheap.Views;

public partial class AddCar : ContentPage
{

    Car car;

    public AddCar(Car car)
    {
        InitializeComponent();

        this.car = car;
    }

    FileIO fileIO = new FileIO();

    CarLoaderSaver carLoaderSaver = new CarLoaderSaver();

    ValidateInput validateInput = new ValidateInput();

    private void SaveClicked(object sender, EventArgs e)
    {
        if (checkTextFields())
        {
            Placeholder.Text = "Input successful!";

            car.SetAll(manufacturer: ManufacturerEntry.Text, model: ModelEntry.Text, mileage: MileageEntry.Text,
                       batteryCapacity: BatteryCapacityEntry.Text, consumption: ConsumptionEntry.Text, batteryLevel: BatteryLevelEntry.Text);

            carLoaderSaver.Save(car);

            carLoaderSaver.Load(car);

        }

        else
        {
            Placeholder.Text = "Invalid input!";
        }

    }

    public bool checkTextFields()
    {
        return !String.IsNullOrEmpty(ManufacturerEntry.Text) &&
               !String.IsNullOrEmpty(ModelEntry.Text) &&
               !String.IsNullOrEmpty(MileageEntry.Text) && (Double.Parse(MileageEntry.Text) >= 0) &&
               !String.IsNullOrEmpty(BatteryCapacityEntry.Text) && (Double.Parse(BatteryCapacityEntry.Text) >= 0) &&
               !String.IsNullOrEmpty(ConsumptionEntry.Text) && (Double.Parse(ConsumptionEntry.Text) >= 0) &&
               !String.IsNullOrEmpty(BatteryLevelEntry.Text) && (Double.Parse(BatteryLevelEntry.Text) >= 0) && (Double.Parse(BatteryLevelEntry.Text) <= 100);
    }
}