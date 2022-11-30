using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Catcheap.Models.Charge_Classes;
using System.Collections.ObjectModel;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Views;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace Catcheap.ViewModel;

public partial class ChargeViewModel : ObservableObject
{
    readonly CarLoaderSaver carLoaderSaver;
    readonly Car car;
    readonly ScooterLoaderSaver scooterLoaderSaver;
    readonly VehicleScooter scooter;

    public ChargeViewModel(CarLoaderSaver carLoaderSaver, Car car, VehicleScooter scooter, ScooterLoaderSaver scooterLoaderSaver)
    {
        this.carLoaderSaver = carLoaderSaver;
        this.car = car;
        this.scooter = scooter;
        this.scooterLoaderSaver = scooterLoaderSaver;

        Charges = new ObservableCollection<Charge>();
    }

    [ObservableProperty]
    ObservableCollection<Charge> charges;

    [ObservableProperty]
    string selectedVehicle;

    [ObservableProperty]
    double? chargingPower;

    [ObservableProperty]
    TimeSpan? startOfCharge;

    [ObservableProperty]
    TimeSpan? endOfCharge;

    [ObservableProperty]
    TimeSpan durationCharge;

    [ObservableProperty]
    double chargedKWh;

    [ICommand]
    async void Add()
    {
        if (chargingPower != null && startOfCharge != null && endOfCharge != null)
        {
            Charge newCharge = new Charge((double)chargingPower, (TimeSpan)startOfCharge, (TimeSpan)endOfCharge);
            Charges.Add(newCharge);

            if (SelectedVehicle == "Car")
            {
                await CarLoaderSaver.Load(car);

                car.UpdateFieldsAfterCharging(newCharge.ChargedKWh);

                await CarLoaderSaver.Save(car);
            }

            if (SelectedVehicle == "Scooter")
            {
                scooterLoaderSaver.Load(scooter);

                scooter.UpdateFieldsAfterCharging(newCharge.ChargedKWh);

                scooterLoaderSaver.Save(scooter);
            }
        }
    }

}