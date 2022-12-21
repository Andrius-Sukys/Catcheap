
using Catcheap.Client.HttpServices;
using Catcheap.Client.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Catcheap.Client.ViewModels;

public class CarViewModel : ListViewModel, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler PropertyChanged;

    public ICommand LoadDataCommand { get; private set; }

    public ICommand CarSelectedCommand { get; private set; }

    public ICommand AddNewCarCommand { get; private set; }

    private Car _selectedCar;
    public Car SelectedCar
    {
        get => _selectedCar;
        set
        {
            if (_selectedCar == value)
                return;

            _selectedCar = value;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedCar)));
        }
    }

    public CarViewModel()
    {
        LoadDataCommand = new Command(async () => await LoadData());
        CarSelectedCommand = new Command(async () => await CarSelected());
        AddNewCarCommand = new Command(async () => await Shell.Current.GoToAsync("addcar"));

        MessagingCenter.Subscribe<AddCarViewModel>(this, "refresh", async (sender) => await LoadData());
        MessagingCenter.Subscribe<AddCarJourneyViewModel>(this, "refresh", async (sender) => await LoadData());
        MessagingCenter.Subscribe<AddCarChargeViewModel>(this, "refresh", async (sender) => await LoadData());
    }

    private async Task CarSelected()
    {
        if (SelectedCar == null)
            return;

        var navigationParameter = new Dictionary<string, object>()
        {
            { "car", SelectedCar }
        };

        MessagingCenter.Send<CarViewModel>(this, SelectedCar.Id.ToString());

        await Shell.Current.GoToAsync("addcar", navigationParameter);

        MainThread.BeginInvokeOnMainThread(() => SelectedCar = null);
    }

}
