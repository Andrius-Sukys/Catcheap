using Catcheap.Client.HttpServices;
using Catcheap.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Catcheap.Client.ViewModels;

public class JourneysViewModel : ListViewModel, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler PropertyChanged;

    public ICommand LoadDataCommand { get; private set; }

    public JourneysViewModel()
    {
        _journeys = new ObservableCollection<CarJourney>();
        GetJourneys();
        LoadDataCommand = new Command(async () => await GetJourneys());
    }

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

    DateTime _date;
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

    protected ObservableCollection<CarJourney> _journeys;
    public ObservableCollection<CarJourney> Journeys
    {
        get => _journeys;
        set => _journeys = value;
    }

    private async Task GetJourneys()
    {
        var journeysCollection = await HttpService<CarJourney>.GetAll($"Car/{SelectedItem.Id}/GetJourneys");

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Journeys.Clear();

            foreach (CarJourney carJourneys in journeysCollection)
            {
                Journeys.Add(carJourneys);
            }
        });
    }
}
