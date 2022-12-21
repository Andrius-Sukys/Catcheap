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

public class StatsViewModel : ListViewModel, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler PropertyChanged;

    public StatsViewModel()
    {
        ViewStatsCommand = new Command(async () => await GetStats());
    }
    public ICommand ViewStatsCommand { get; private set; }

    int _chargesCountWeek;
    public int ChargesCountWeek
    {
        get => _chargesCountWeek;
        set
        {
            if (_chargesCountWeek == value)
                return;

            _chargesCountWeek = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChargesCountWeek)));
        }
    }

    int _chargesCountMonth;
    public int ChargesCountMonth
    {
        get => _chargesCountMonth;
        set
        {
            if (_chargesCountMonth == value)
                return;

            _chargesCountMonth = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChargesCountMonth)));
        }
    }

    int _chargesCountYear;
    public int ChargesCountYear
    {
        get => _chargesCountYear;
        set
        {
            if (_chargesCountYear == value)
                return;

            _chargesCountYear = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChargesCountYear)));
        }
    }

    int _chargesCountAll;
    public int ChargesCountAll
    {
        get => _chargesCountAll;
        set
        {
            if (_chargesCountAll == value)
                return;

            _chargesCountAll = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChargesCountAll)));
        }
    }

    int _journeysCountWeek;
    public int JourneysCountWeek
    {
        get => _journeysCountWeek;
        set
        {
            if (_journeysCountWeek == value)
                return;

            _journeysCountWeek = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JourneysCountWeek)));
        }
    }

    int _journeysCountMonth;
    public int JourneysCountMonth
    {
        get => _journeysCountMonth;
        set
        {
            if (_journeysCountMonth == value)
                return;

            _journeysCountWeek = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JourneysCountMonth)));
        }
    }

    int _journeysCountYear;
    public int JourneysCountYear
    {
        get => _journeysCountYear;
        set
        {
            if (_journeysCountYear == value)
                return;

            _journeysCountYear = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JourneysCountYear)));
        }
    }

    int _journeysCountAll;
    public int JourneysCountAll
    {
        get => _journeysCountAll;
        set
        {
            if (_journeysCountAll == value)
                return;

            _journeysCountAll = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JourneysCountAll)));
        }
    }

    double _journeyDistanceWeek;
    public double JourneyDistanceWeek
    {
        get => _journeyDistanceWeek;
        set
        {
            if (_journeyDistanceWeek == value)
                return;

            _journeyDistanceWeek = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JourneyDistanceWeek)));
        }
    }

    double _journeyDistanceMonth;
    public double JourneyDistanceMonth
    {
        get => _journeyDistanceMonth;
        set
        {
            if (_journeyDistanceMonth == value)
                return;

            _journeyDistanceMonth = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JourneyDistanceMonth)));
        }
    }

    double _journeyDistanceYear;
    public double JourneyDistanceYear
    {
        get => _journeyDistanceYear;
        set
        {
            if (_journeyDistanceYear == value)
                return;

            _journeyDistanceYear = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JourneyDistanceYear)));
        }
    }

    double _journeyDistanceAll;
    public double JourneyDistanceAll
    {
        get => _journeyDistanceAll;
        set
        {
            if (_journeyDistanceAll == value)
                return;

            _journeyDistanceAll = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JourneyDistanceAll)));
        }
    }

    double _consumptionWeek;
    public double ConsumptionWeek
    {
        get => _consumptionWeek;
        set
        {
            if (_consumptionWeek == value)
                return;

            _consumptionWeek = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConsumptionWeek)));
        }
    }

    double _consumptionMonth;
    public double ConsumptionMonth
    {
        get => _consumptionMonth;
        set
        {
            if (_consumptionMonth == value)
                return;

            _consumptionMonth = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConsumptionMonth)));
        }
    }

    double _consumptionYear;
    public double ConsumptionYear
    {
        get => _consumptionYear;
        set
        {
            if (_consumptionYear == value)
                return;

            _consumptionYear = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConsumptionYear)));
        }
    }

    double _consumptionAll;
    public double ConsumptionAll
    {
        get => _consumptionAll;
        set
        {
            if (_consumptionAll == value)
                return;

            _consumptionAll = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ConsumptionAll)));
        }
    }

    double _moneySpentWeek;
    public double MoneySpentWeek
    {
        get => _moneySpentWeek;
        set
        {
            if (_moneySpentWeek == value)
                return;

            _moneySpentWeek = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MoneySpentWeek)));
        }
    }

    double _moneySpentMonth;
    public double MoneySpentMonth
    {
        get => _moneySpentMonth;
        set
        {
            if (_moneySpentMonth == value)
                return;

            _moneySpentMonth = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MoneySpentMonth)));
        }
    }

    double _moneySpentYear;
    public double MoneySpentYear
    {
        get => _moneySpentYear;
        set
        {
            if (_moneySpentYear == value)
                return;

            _moneySpentYear = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MoneySpentYear)));
        }
    }

    double _moneySpentAll;
    public double MoneySpentAll
    {
        get => _moneySpentAll;
        set
        {
            if (_moneySpentAll == value)
                return;

            _moneySpentAll = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MoneySpentAll)));
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

    private async Task GetStats()
    {

        ChargesCountWeek = await HttpService<int>.Get($"CarStats/{SelectedItem.Id}/ChargesSince/2022-12-14");
        ChargesCountMonth = await HttpService<int>.Get($"CarStats/{SelectedItem.Id}/ChargesSince/2022-11-21");
        ChargesCountYear = await HttpService<int>.Get($"CarStats/{SelectedItem.Id}/ChargesSince/2021-12-11");
        ChargesCountAll = await HttpService<int>.Get($"CarStats/{SelectedItem.Id}/ChargesSince/0001-01-01");

        JourneysCountWeek = await HttpService<int>.Get($"CarStats/{SelectedItem.Id}/JourneysSince/2022-12-14");
        JourneysCountMonth = await HttpService<int>.Get($"CarStats/{SelectedItem.Id}/JourneysSince/2022-11-21");
        JourneysCountYear = await HttpService<int>.Get($"CarStats/{SelectedItem.Id}/JourneysSince/2021-12-11");
        JourneysCountAll = await HttpService<int>.Get($"CarStats/{SelectedItem.Id}/JourneysSince/0001-01-01");

        JourneyDistanceWeek = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/JourneyDistanceSince/2022-12-14"), 2);
        JourneyDistanceMonth = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/JourneyDistanceSince/2022-11-21"), 2);
        JourneyDistanceYear = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/JourneyDistanceSince/2021-12-11"), 2);
        JourneyDistanceAll = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/JourneyDistanceSince/0001-01-01"), 2);

        ConsumptionWeek = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/ConsumptionSince/2022-12-14"), 2);
        ConsumptionMonth = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/ConsumptionSince/2022-11-21"), 2);
        ConsumptionYear = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/ConsumptionSince/2021-12-11"), 2);
        ConsumptionAll = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/ConsumptionSince/0001-01-01"), 2);

        MoneySpentWeek = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/MoneySince/2022-12-14"), 2);
        MoneySpentMonth = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/MoneySince/2022-11-21"), 2);
        MoneySpentYear = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/MoneySince/2021-12-11"), 2);
        MoneySpentAll = Math.Round(await HttpService<double>.Get($"CarStats/{SelectedItem.Id}/MoneySince/0001-01-01"), 2);

        MessagingCenter.Send(this, "refresh");

        await Shell.Current.GoToAsync("..");
    }
}
