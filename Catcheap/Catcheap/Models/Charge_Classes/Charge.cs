using System.ComponentModel;
using Catcheap.Models.FileIO_Classes;

namespace Catcheap.Models.Charge_Classes;

public class Charge
{
    public Charge(double ChargingPower, TimeSpan StartOfCharge, TimeSpan EndOfCharge)

    {
        chargingPower = ChargingPower;
        startOfCharge = StartOfCharge;
        endOfCharge = EndOfCharge;
        durationCharge = calculateDurationOfCharge(EndOfCharge, StartOfCharge);
        chargedKWh = calculateChargedKWh(chargingPower, durationCharge);
    }
    public double chargingPower { get; set; }

    public TimeSpan startOfCharge { get; set; }

    public TimeSpan endOfCharge { get; set; }

    public TimeSpan durationCharge { get; set; }

    public double chargedKWh { get; set; }

    TimeSpan calculateDurationOfCharge(TimeSpan EndOfCharge, TimeSpan StartOfCharge)
    {
        if (EndOfCharge > StartOfCharge)
            return EndOfCharge - StartOfCharge;
        else if (EndOfCharge < StartOfCharge)
            return new TimeSpan(24, 0, 0) - StartOfCharge + EndOfCharge;
        else
            return new TimeSpan(0, 0, 0);
    }

    double calculateChargedKWh(double ChargingPower, TimeSpan durationCharge)
    {
        return (ChargingPower * durationCharge.Hours + durationCharge.Minutes / 60 + durationCharge.Seconds / 3600) / 1000;
    }

}
