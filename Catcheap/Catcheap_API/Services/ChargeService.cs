namespace Catcheap_API.Services;

public class ChargeService
{
    public TimeSpan CalculateDurationOfCharge(DateTime StartOfCharge, DateTime EndOfCharge)
    {
        return EndOfCharge.Subtract(StartOfCharge);
    }

    public double CalculateChargedKWh(double ChargingPower, TimeSpan durationOfCharge)
    {
        return (ChargingPower * (durationOfCharge.Hours + durationOfCharge.Minutes / 60 + durationOfCharge.Seconds / 3600)) / 1000;
    }
}
