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

        if (JourneyField.JourneyDistance != null && JourneyField.JourneyDistance >= 0)
        {
            fileIO.UpdateTextFile("Distance: " + JourneyField.JourneyDistance + " Date: " + JourneyField.JourneyDate + '\n', "journeys.txt");

            if (JourneyField.SelectedItem == "Car")
            {
                

                CarLoaderSaver carLoaderSaver = new CarLoaderSaver();
                Car car = new Car();

                carLoaderSaver.Load(car);

                car.UpdateCarFieldsAfterJourney(journeyDistance: (double)JourneyField.JourneyDistance);

                carLoaderSaver.Save(car);
            }

            if (JourneyField.SelectedItem == "Scooter")
            {

                ScooterLoaderSaver scooterLS = new ScooterLoaderSaver();
                VehicleScooter scooter = new VehicleScooter();
                scooterLS.Load(scooter);

                scooter.UpdateFieldsAfterJourney(JourneyDistance: (double)JourneyField.JourneyDistance, AdditionalConsumption: (scooter.Consumption / scooter.BatteryCapacity * 100)/scooter.ExpectedRange);

                scooterLS.Save(scooter);
            }

            else
            {
                JourneyField.ClearFields();
            }

        }

        JourneyField.ClearFields();

    }
}
