using Catcheap.Client.HttpServices;
using Catcheap.Client.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Client.ViewModels;

public class ListViewModel : INotifyPropertyChanged
{
    public ListViewModel()
    {
        _cars = new ObservableCollection<Car>();
        Task.Run(LoadData);
    }

    protected ObservableCollection<Car> _cars;
    public ObservableCollection<Car> Cars
    {
        get => _cars;
        set => _cars = value;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    private bool _isRefreshing = false;
    public bool IsRefreshing
    {
        get => _isRefreshing;
        set
        {
            if (_isRefreshing == value)
                return;

            _isRefreshing = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsRefreshing)));
        }
    }

    private bool _isBusy = false;
    public bool IsBusy
    {
        get => _isBusy;
        set
        {
            if (_isBusy == value)
                return;

            _isBusy = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
        }
    }

    public async Task LoadData()
    {
        if (IsBusy)
            return;

        try
        {
            IsRefreshing = true;
            IsBusy = true;

            var carsCollection = await HttpService<Car>.GetAll("Car");

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Cars.Clear();

                foreach (Car car in carsCollection)
                {
                    Cars.Add(car);
                }
            });
        }
        finally
        {
            IsRefreshing = false;
            IsBusy = false;
        }
    }
}
