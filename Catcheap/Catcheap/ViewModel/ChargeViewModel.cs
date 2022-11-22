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

    CarLoaderSaver carLoaderSaver;
    Car car;
    ScooterLoaderSaver scooterLoaderSaver;
    VehicleScooter scooter;

    public ChargeViewModel(CarLoaderSaver carLoaderSaver, Car car, VehicleScooter scooter, ScooterLoaderSaver scooterLoaderSaver)
    {
        this.carLoaderSaver = carLoaderSaver;
        this.car = car;
        Charges = new ObservableCollection<Charge>();
        this.scooter = scooter;
        this.scooterLoaderSaver = scooterLoaderSaver;
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
    void Add()
    {
        if(chargingPower != null && startOfCharge != null && endOfCharge != null)
        {
            Charge newCharge = new Charge((double)chargingPower, (TimeSpan)startOfCharge, (TimeSpan)endOfCharge);
            Charges.Add(newCharge);

            if(SelectedVehicle == "Car")
            {
                carLoaderSaver.Load(car);

                car.UpdateFieldsAfterCharging(newCharge.chargedKWh);

                carLoaderSaver.Save(car);
            }

            if (SelectedVehicle == "Scooter")
            {
                scooterLoaderSaver.Load(scooter);

                scooter.UpdateFieldsAfterCharging(newCharge.chargedKWh);

                scooterLoaderSaver.Save(scooter);
            }
        }
    }

}
