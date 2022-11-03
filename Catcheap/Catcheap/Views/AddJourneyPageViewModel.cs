using System.ComponentModel;
using System.Windows.Input;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;
using Microsoft.Extensions.DependencyInjection;

namespace Catcheap.Views;

public class AddJourneyPageViewModel : INotifyPropertyChanged
{
    public JourneyField JourneyField { get; } = new JourneyField();

    Car car;

    public AddJourneyPageViewModel(Car car)
    {
        PostJourneys = new Command(AddJourney);

        this.car = car;
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
                JourneysLoaderSaver journeysLoaderSaver = new JourneysLoaderSaver();
                

                carLoaderSaver.Load(car);
                journeysLoaderSaver.Load(car.GetJourneys());

                car.UpdateCarFieldsAfterJourney(journeyDistance: (double)JourneyField.JourneyDistance);

                carLoaderSaver.Save(car);
                journeysLoaderSaver.Save(car.GetJourneys());
            }

            if (JourneyField.SelectedItem == "Scooter")
            {

                ScooterLoaderSaver scooterLS = new ScooterLoaderSaver();
                JourneysLoaderSaver journeysLoaderSaver = new JourneysLoaderSaver();
                VehicleScooter scooter = new VehicleScooter();

                scooterLS.Load(scooter);
                journeysLoaderSaver.Load(scooter.GetJourneys());

                scooter.UpdateFieldsAfterJourney(JourneyDistance: (double)JourneyField.JourneyDistance, AdditionalConsumption: (scooter.Consumption / scooter.BatteryCapacity * 100)/scooter.ExpectedRange);

                scooterLS.Save(scooter);
                journeysLoaderSaver.Save(scooter.GetJourneys());
            }

            else
            {
                JourneyField.ClearFields();
            }

        }

        JourneyField.ClearFields();

    }
}
