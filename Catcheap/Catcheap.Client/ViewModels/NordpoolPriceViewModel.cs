using Catcheap.Client.HttpServices;
using Catcheap.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Catcheap.Client.ViewModels;

public class NordpoolPriceViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand GetPricesCommand { get; private set; }

    public NordpoolPriceViewModel()
    {
        _prices = new ObservableCollection<NordpoolPrice>();
        GetPricesCommand = new Command(async () => await GetPrices());
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

    DateTime _dateAndTime;
    public DateTime DateAndTime
    {
        get => _dateAndTime;
        set
        {
            if (_dateAndTime == value)
                return;

            _dateAndTime = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateAndTime)));
        }
    }

    double _price;
    public double Price
    {
        get => _price;
        set
        {
            if (_price == value)
                return;

            _price = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Price)));
        }
    }

    NordpoolPrice _lowestPriceWeek;
    public NordpoolPrice LowestPriceWeek
    {
        get => _lowestPriceWeek;
        set
        {
            if (_lowestPriceWeek == value)
                return;

            _lowestPriceWeek = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LowestPriceWeek)));
        }
    }

    double _highestPriceWeek;
    public double HighestPriceWeek
    {
        get => _highestPriceWeek;
        set
        {
            if (_highestPriceWeek == value)
                return;

            _highestPriceWeek = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HighestPriceWeek)));
        }
    }

    protected ObservableCollection<NordpoolPrice> _prices;
    public ObservableCollection<NordpoolPrice> Prices
    {
        get => _prices;
        set => _prices = value;
    }

    private async Task GetPrices()
    {
        LowestPriceWeek = await HttpService<NordpoolPrice>.Get("NordpoolPrice/CheapestSince/2012-05-18");

        var pricesCollection = await HttpService<NordpoolPrice>.GetAll("NordpoolPrice");

        var pricesCollectionSorted = pricesCollection.OrderByDescending(x => x.DateAndTime.Minute);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Prices.Clear();

            foreach (NordpoolPrice price in pricesCollection)
            {
                Prices.Add(price);
            }
        });
    }

}
