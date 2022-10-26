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
    public ChargeViewModel()
    {
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
    void Add()
    {
        if(chargingPower != null && startOfCharge != null && endOfCharge != null)
        {
            Charge newCharge = new Charge((double)chargingPower, (TimeSpan)startOfCharge, (TimeSpan)endOfCharge);
            Charges.Add(newCharge);

            if(SelectedVehicle == "Car")
            {
                CarLoaderSaver carLoaderSaver = new CarLoaderSaver();
                Car car = new Car();

                carLoaderSaver.Load(car);

                car.UpdateFieldsAfterCharging(newCharge.chargedKWh);

                carLoaderSaver.Save(car);
            }

            if (SelectedVehicle == "Scooter")
            {
                ScooterLoaderSaver scooterLoaderSaver = new ScooterLoaderSaver();
                VehicleScooter scooter = new VehicleScooter();

                scooterLoaderSaver.Load(scooter);

                scooter.UpdateFieldsAfterCharging(newCharge.chargedKWh);

                scooterLoaderSaver.Save(scooter);
            }
        }
    }

}
