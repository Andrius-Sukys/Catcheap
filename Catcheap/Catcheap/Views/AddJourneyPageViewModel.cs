using System.ComponentModel;
using System.Windows.Input;
using Catcheap.Models.FileIO_Classes;
using Catcheap.Models.Vehicles_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;
using Microsoft.Extensions.DependencyInjection;
using Plugin.LocalNotification;

namespace Catcheap.Views;

public class AddJourneyPageViewModel
{
    public JourneyField JourneyField { get; }

    readonly Car car;
    readonly CarLoaderSaver carLoaderSaver;
    readonly ScooterLoaderSaver scooterLS;
    readonly VehicleScooter scooter;
    readonly FileIO fileIO;
    readonly JourneysLoaderSaver journeysLoaderSaver;

    public AddJourneyPageViewModel(Car car, CarLoaderSaver carLoaderSaver, ScooterLoaderSaver scooterLoaderSaver, VehicleScooter scooter, FileIO fileIO, JourneyField journeyField,
                                   JourneysLoaderSaver journeysLoaderSaver)
    {
        PostJourneys = new Command(AddJourney);

        this.car = car;
        this.carLoaderSaver = carLoaderSaver;
        this.scooterLS = scooterLoaderSaver;
        this.scooter = scooter;
        this.fileIO = fileIO;
        this.JourneyField = journeyField;
        this.journeysLoaderSaver = journeysLoaderSaver;
    }

    public ICommand PostJourneys { get; }

    public async void AddJourney()
    {

        if (JourneyField.JourneyDistance != null && JourneyField.JourneyDistance >= 0)
        {
            FileIO.UpdateTextFile("Distance: " + JourneyField.JourneyDistance + " Date: " + JourneyField.JourneyDate + '\n', "journeys.txt");

            if (JourneyField.SelectedItem == "Car")
            {   
                await CarLoaderSaver.Load(car);
                journeysLoaderSaver.Load(car.GetJourneys());

                car.UpdateCarFieldsAfterJourney(journeyDistance: (double)JourneyField.JourneyDistance);

                //await CarLoaderSaver.Save(car);
                //journeysLoaderSaver.Save(car.GetJourneys());
            }

            if (JourneyField.SelectedItem == "Scooter")
            {
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
