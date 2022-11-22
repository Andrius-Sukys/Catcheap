using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Notification_Classes;
using Catcheap.Models.Validation_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;

namespace Catcheap.Views;

public partial class AddCar : ContentPage
{

    Car car;
    CarLoaderSaver carLoaderSaver;
    ValidateInput<string> validateInput;
    
    public AddCar(Car car, CarLoaderSaver carLoaderSaver, ValidateInput<string> validateInput)
    {
        InitializeComponent();

        this.car = car;
        this.carLoaderSaver = carLoaderSaver;
        this.validateInput = validateInput;

    }

    private async void SaveClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Alert", "Invalid input!", "OK");
        if (CheckTextFields())
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

    public bool CheckTextFields()
    {
        return validateInput.ValidateInputNull(ManufacturerEntry.Text) &&
               validateInput.ValidateInputNull(ModelEntry.Text) &&
               validateInput.ValidateInputNull(MileageEntry.Text) && Double.TryParse(MileageEntry.Text, out double parsedValueMileage) && (parsedValueMileage >= 0) &&
               validateInput.ValidateInputNull(BatteryCapacityEntry.Text) && Double.TryParse(BatteryCapacityEntry.Text, out double parsedValueCapacity) && (parsedValueCapacity >= 0) &&
               validateInput.ValidateInputNull(ConsumptionEntry.Text) && Double.TryParse(ConsumptionEntry.Text, out double parsedValueConsumption) && (parsedValueConsumption >= 0) &&
               validateInput.ValidateInputNull(BatteryLevelEntry.Text) && Double.TryParse(BatteryLevelEntry.Text, out double parsedValueBatteryLevel) && (parsedValueBatteryLevel >= 0) && (parsedValueBatteryLevel <= 100);
    }

}