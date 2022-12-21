using Catcheap.Client.HttpServices;
using Catcheap.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Catcheap.Client.ViewModels;

public class AddCarChargeViewModel : ListViewModel, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler PropertyChanged;

    public ICommand SaveCommand { get; private set; }

    public ICommand DoneEditingCommand { get; private set; }

    public ICommand InsertChargeCommand { get; private set; }

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

    double _chargingPower;
    public double ChargingPower
    {
        get => _chargingPower;
        set
        {
            if (_chargingPower == value)
                return;

            _chargingPower = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChargingPower)));
        }
    }

    DateTime _startOfCharge = DateTime.Now;
    public DateTime StartOfCharge
    {
        get => _startOfCharge;
        set
        {
            if (_startOfCharge == value)
                return;

            _startOfCharge = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartOfCharge)));
        }
    }

    DateTime _endOfCharge = DateTime.Now.AddHours(1);
    public DateTime EndOfCharge
    {
        get => _endOfCharge;
        set
        {
            if (_endOfCharge == value)
                return;

            _endOfCharge = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndOfCharge)));
        }
    }

    double _chargingPrice;
    public double ChargingPrice
    {
        get => _chargingPrice;
        set
        {
            if (_chargingPrice == value)
                return;

            _chargingPrice = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChargingPrice)));
        }
    }

    private Car _selectedItem;
    public Car SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (_selectedItem == value)
                return;

            _selectedItem = value;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
        }
    }

    public AddCarChargeViewModel()
    {
        InsertChargeCommand = new Command(async () => await InsertCharge());
        DoneEditingCommand = new Command(async () => await DoneEditing());
        SaveCommand = new Command(async () => await SaveData());
    }

    private async Task SaveData()
    {
        if (Id == 0)
            await InsertCharge();
        //else
            //await UpdateCharge();
    }

    private async Task InsertCharge()
    {
        CarCharge chargeToAdd = new CarCharge
        {
            StartOfCharge = StartOfCharge,
            EndOfCharge = EndOfCharge,
            ChargingPower = ChargingPower,
            ChargingPrice = 0.3
        };

        var charge = await HttpService<CarCharge>.Add(chargeToAdd, $"CarCharge/{SelectedItem.Id}/AddCharge");

        await HttpService<Car>.Update(SelectedItem, $"Car/{SelectedItem.Id}/UpdateAfterCharge/{charge.Id}");

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
