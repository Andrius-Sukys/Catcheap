namespace Catcheap.Models.Charge_Classes;

public class Charge
{
    public Charge(double ChargingPower, TimeSpan StartOfCharge, TimeSpan EndOfCharge)

    {
        this.ChargingPower = ChargingPower;
        this.StartOfCharge = StartOfCharge;
        this.EndOfCharge = EndOfCharge;
        DurationCharge = Charge.CalculateDurationOfCharge(EndOfCharge, StartOfCharge);
        ChargedKWh = Charge.CalculateChargedKWh(this.ChargingPower, DurationCharge);
    }
    public double ChargingPower { get; set; }

    public TimeSpan StartOfCharge { get; set; }

    public TimeSpan EndOfCharge { get; set; }

    public TimeSpan DurationCharge { get; set; }

    public double ChargedKWh { get; set; }

    static TimeSpan CalculateDurationOfCharge(TimeSpan EndOfCharge, TimeSpan StartOfCharge)
    {
        if (EndOfCharge > StartOfCharge)
            return EndOfCharge - StartOfCharge;
        else if (EndOfCharge < StartOfCharge)
            return TimeSpan.FromHours(24) - StartOfCharge + EndOfCharge;
        else
            return TimeSpan.FromHours(0);
    }

    static double CalculateChargedKWh(double ChargingPower, TimeSpan durationCharge)
    {
        return (ChargingPower * durationCharge.Hours + durationCharge.Minutes / 60 + durationCharge.Seconds / 3600) / 1000;
    }

}
