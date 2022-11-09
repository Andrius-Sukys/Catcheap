namespace Catcheap.Models.EventArgs_Classes;

public  class LowOnBatteryEventArgs : EventArgs
{
    public double BatteryLevel;

    public LowOnBatteryEventArgs(double batteryLevel)
    {
        BatteryLevel = batteryLevel;
    }
}
