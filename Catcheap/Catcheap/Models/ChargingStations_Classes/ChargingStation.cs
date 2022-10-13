using System.Text;


/* Unmerged change from project 'Catcheap (net6.0-windows10.0.19041.0)'
Before:
using System.Linq;
After:
using System.Linq;
using Catcheap;
using Catcheap.Models.ChargingStations_Classes;
*/
using System.Linq;

namespace Catcheap.Models.ChargingStations_Classes;

public class ChargingStation
{
    public ChargingStation() { }
    public ChargingStation(string city, string holder, string address)
    {
        this.city = city;
        this.holder = holder;
        this.address = address;
    }

    public string city { get; }
    public string holder { get; }
    public string address { get; }

    public List<ChargingStation> ChargingStations { get; set; }

    public async void getChargingStations()
    {
        ChargingStations = new List<ChargingStation>();

        using (StreamReader reader = new StreamReader(await FileSystem.Current.OpenAppPackageFileAsync("Resources/Files/chargingspots.txt")))
        {
            string line = string.Empty;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                ChargingStations.Add(new ChargingStation(parts[0], parts[1], parts[2]));
            }
        }
    }

    public string displayChargingStations(List<ChargingStation> stations = null)
    {
        stations = stations ?? ChargingStations;
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ChargingStation ch in stations)
        {
            stringBuilder.AppendFormat("{0} {1} {2} \n", ch.holder, ch.address, ch.city);
        }
        return stringBuilder.ToString();
    }

    public string FilterByCity(string city)
    {
        List<ChargingStation> subList = ChargingStations.Where(p => p.city == city).ToList();
        return displayChargingStations(subList);
    }

}
