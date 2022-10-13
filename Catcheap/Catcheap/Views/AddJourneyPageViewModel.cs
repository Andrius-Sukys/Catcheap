using System.ComponentModel;
using System.Windows.Input;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace Catcheap.Views;

public class AddJourneyPageViewModel : INotifyPropertyChanged
{
    public JourneyField JourneyField { get; } = new JourneyField();
    public AddJourneyPageViewModel()
    {
        PostJourneys = new Command(AddJourney);
    }

    public ICommand PostJourneys { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public void AddJourney()
    {
        FileIO fileIO = new FileIO();

        fileIO.UpdateTextFile("Distance: " + JourneyField.JourneyDistance + " Date: " + JourneyField.JourneyDate + '\n', "journeys.txt");

        if (JourneyField.SelectedIndex == 0)
        {
            CarLoaderSaver carLoaderSaver = new CarLoaderSaver();
            Car car = new Car();

            carLoaderSaver.Load(car);

            car.UpdateCarFieldsAfterJourney((double)JourneyField.JourneyDistance, car.batteryLevel, car.batteryCapacity, car.consumption);

            carLoaderSaver.Save(car);
        }

        if (JourneyField.SelectedIndex == 1)
        {
            ScooterLoaderSaver scooterLS = new ScooterLoaderSaver();
            VehicleScooter scooter = new VehicleScooter();
            scooterLS.Load(scooter);

            ((Vehicle)scooter).UpdateFieldsAfterJourney((double)JourneyField.JourneyDistance, scooter.batteryLevel, scooter.batteryCapacity, scooter.consumption);

            scooterLS.Save(scooter);
        }

        else
        { 
            JourneyField.ClearFields();
        }

        JourneyField.ClearFields();

    }
}
