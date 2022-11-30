using Catcheap.Models.Exception_Classes;
using System.Text;

namespace Catcheap.Models.ChargingStations_Classes;

public class ChargingStation
{
    public ChargingStation()
    {
    }
    public ChargingStation(string city, string holder, string address)
    {
        City = city;
        Holder = holder;
        Address = address;
    }

    public string City { get; }
    public string Holder { get; }
    public string Address { get; }

    public List<ChargingStation> ChargingStations { get; set; }

    public async void GetChargingStations()
    {
        ChargingStations = new List<ChargingStation>();

        using StreamReader reader = new(await FileSystem.Current.OpenAppPackageFileAsync("Resources/Files/chargingspots.txt"));
        string line = string.Empty;
        try
        {
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                ChargingStations.Add(new ChargingStation(parts[0], parts[1], parts[2]));
            }
        }
        catch
        {
            throw;
        }
    }

    public string DisplayChargingStations(List<ChargingStation> stations = null)
    {
        stations ??= ChargingStations;
        StringBuilder stringBuilder = new ();
        foreach (ChargingStation ch in stations)
        {
            try
            {
                stringBuilder.AppendFormat("{0} {1} {2} \n", ch.Holder, ch.Address, ch.City);
            }
            catch
            {
                throw;
            }
            
        }
        return stringBuilder.ToString();
    }

    public string FilterByCity(string city)
    {
        List<ChargingStation> subList = ChargingStations.Where(p => p.City == city).ToList();
        return DisplayChargingStations(subList);
    }

}
