using Catcheap.Client.HttpServices;
using Catcheap.Client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Catcheap.Client.ViewModels;

public class AddCarJourneyViewModel : ListViewModel, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler PropertyChanged;

    public ICommand SaveCommand { get; private set; }

    public ICommand DoneEditingCommand { get; private set; }

    public ICommand InsertJourneyCommand { get; private set; }

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

    DateTime _date = DateTime.Now;
    public DateTime Date
    {
        get => _date;
        set
        {
            if (_date == value)
                return;

            _date = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Date)));
        }
    }

    double _distance;
    public double Distance
    {
        get => _distance;
        set
        {
            if (_distance == value)
                return;

            _distance = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Distance)));
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

    string _startLocation;
    public string StartLocation
    {
        get => _startLocation;
        set
        {
            if (_startLocation == value)
                return;

            _startLocation = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StartLocation)));
        }
    }

    string _endLocation;
    public string EndLocation
    {
        get => _endLocation;
        set
        {
            if (_endLocation == value)
                return;

            _endLocation = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EndLocation)));
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

    public AddCarJourneyViewModel()
    {
        InsertJourneyCommand = new Command(async () => await InsertJourney());
        DoneEditingCommand = new Command(async () => await DoneEditing());
        SaveCommand = new Command(async () => await SaveData());
    }

    private async Task SaveData()
    {
        if (Id == 0)
            await InsertJourney();
        //else
        //await UpdateCharge();
    }

    private async Task InsertJourney()
    {
        CarJourney journeyToAdd = new CarJourney()
        {
            Id = Id,
            Distance = Distance,
            Date = Date,
            StartLocation = StartLocation,
            EndLocation = EndLocation
        };

        var journey = await HttpService<CarJourney>.Add(journeyToAdd, $"CarJourney/{SelectedItem.Id}/AddJourney");

        await HttpService<Car>.Update(SelectedItem, $"Car/{SelectedItem.Id}/UpdateAfterJourney/{journey.Id}");
        
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
