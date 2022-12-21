using Catcheap.Client.HttpServices;
using Catcheap.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;

namespace Catcheap.Client.ViewModels;

public class AddCarViewModel : CarViewModel, INotifyPropertyChanged
{

    public new event PropertyChangedEventHandler PropertyChanged;

    public ICommand DoneEditingCommand { get; private set; }

    public ICommand SaveCommand { get; private set; }

    public ICommand DeleteCommand { get; private set; }

    int _id;
    public int Id
    {
        get => _id;
        set
        {
            if (_id == value)
                return;

            _id = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
        }
    }

    string _manufacturer;
    public string Manufacturer
    {
        get => _manufacturer;
        set
        {
            if (_manufacturer == value)
                return;

            _manufacturer = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Manufacturer)));
        }
    }

    string _model;
    public string Model
    {
        get => _model;
        set
        {
            if (_model == value)
                return;

            _model = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Model)));
        }
    }

    string _numberplate;
    public string Numberplate
    {
        get => _numberplate;
        set
        {
            if (_numberplate == value)
                return;

            _numberplate = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Numberplate)));
        }
    }

    int _yearOfManufacture;
    public int YearOfManufacture
    {
        get => _yearOfManufacture;
        set
        {
            if (_yearOfManufacture == value)
                return;

            _yearOfManufacture = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(YearOfManufacture)));
        }
    }

    DateTime _motExpiry;
    public DateTime MOTExpiry
    {
        get => _motExpiry;
        set
        {
            if (_motExpiry == value)
                return;

            _motExpiry = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MOTExpiry)));
        }
    }

    double _expectedRange;
    public double ExpectedRange
    {
        get => _expectedRange;
        set
        {
            if (_expectedRange == value)
                return;

            _expectedRange = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ExpectedRange)));
        }
    }

    double _batteryCapacity;
    public double BatteryCapacity
    {
        get => _batteryCapacity;
        set
        {
            if (_batteryCapacity == value)
                return;

            _batteryCapacity = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BatteryCapacity)));
        }
    }

    double _consumption;
    public double Consumption
    {
        get => _consumption;
        set
        {
            if (_consumption == value)
                return;

            _consumption = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Consumption)));
        }
    }

    double _batteryLevel;
    public double BatteryLevel
    {
        get => _batteryLevel;
        set
        {
            if (_batteryLevel == value)
                return;

            _batteryLevel = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BatteryLevel)));
        }
    }

    double _mileage;
    public double Mileage
    {
        get => _mileage;
        set
        {
            if (_mileage == value)
                return;

            _mileage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Mileage)));
        }
    }

    public AddCarViewModel()
    {
        DoneEditingCommand = new Command(async () => await DoneEditing());
        SaveCommand = new Command(async () => await SaveData());
        DeleteCommand = new Command(async () => await DeleteCar());
    }

    private async Task SaveData()
    {
        if (Id == 0)
            await InsertCar();
        else
            await UpdateCar();
    }

    private async Task InsertCar()
    {
        Car carToAdd = new Car
        {
            Id = Id,
            Manufacturer = Manufacturer,
            Model = Model,
            Numberplate = Numberplate,
            YearOfManufacture = YearOfManufacture,
            ExpectedRange = ExpectedRange,
            BatteryCapacity = BatteryCapacity,
            Consumption = Consumption,
            BatteryLevel = BatteryLevel,
            Mileage = Mileage
        };

        await HttpService<Car>.Add(carToAdd, "Car");

        await Shell.Current.GoToAsync("..");

        MessagingCenter.Send(this, "refresh");

        
    }

    private async Task UpdateCar()
    {
        Car carToUpdate = new Car
        {
            Id = Id,
            Manufacturer = Manufacturer,
            Model = Model,
            Numberplate = Numberplate,
            YearOfManufacture = YearOfManufacture,
            ExpectedRange = ExpectedRange,
            BatteryCapacity = BatteryCapacity,
            Consumption = Consumption,
            BatteryLevel = BatteryLevel,
            Mileage = Mileage
        };

        await HttpService<Car>.Update(carToUpdate, $"Car/{Id}");

        MessagingCenter.Send(this, "refresh");

        await Shell.Current.GoToAsync("..");
    }

    private async Task DeleteCar()
    {
        if (Id == 0)
            return;

        await HttpService<Car>.Delete(Id, "Car");

        MessagingCenter.Send(this, "refresh");

        await Shell.Current.GoToAsync("..");

    }

    private async Task DoneEditing()
    {
        await Shell.Current.GoToAsync("..");
    }

}
