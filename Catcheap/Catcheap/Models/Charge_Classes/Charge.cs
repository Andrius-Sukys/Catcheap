using System.ComponentModel;
using Catcheap.Models.FileIO_Classes;

namespace Catcheap.Models.Charge_Classes;

public class Charge : INotifyPropertyChanged
{
    double chargingSpeed { get; set; }
    public double ChargingSpeed
    {
        get { return chargingSpeed; }
        set { chargingSpeed = value; OnPropertyChanged(nameof(ChargingSpeed)); }
    }

    double chargingPrice { get; set; }
    public double ChargingPrice
    {
        get { return chargingPrice; }
        set { chargingPrice = value; OnPropertyChanged(nameof(ChargingPrice)); }
    }
    DateTime startOfCharge { get; set; }
    public DateTime StartOfCharge
    {
        get { return startOfCharge; }
        set { startOfCharge = value; OnPropertyChanged(nameof(StartOfCharge)); }
    }
    DateTime endOfCharge { get; set; }

    public DateTime EndOfCharge
    {
        get { return EndOfCharge; }
        set { EndOfCharge = value; OnPropertyChanged(nameof(EndOfCharge)); }
    }
    void OnPropertyChanged(string name) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    public event PropertyChangedEventHandler PropertyChanged;

    public void ClearFields()
    {
        ChargingSpeed = 0;
        ChargingPrice = 0;
    }

    public void ClearCharges()
    {
        FileIO fileIO = new FileIO();
        if ("charges.txt" != null)
            fileIO.ClearTextFile("charges.txt");
    }
}
