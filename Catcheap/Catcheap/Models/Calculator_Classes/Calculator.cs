namespace Catcheap.Models.Calculator_Classes;

public class Calculator
{
    public double Distance { get; set; }
    public double Consumption { get; set; }
    public double ElectricityPrice { get; set; }

    public double CalculatePrice()
    {
        if (Distance <= 0 || Consumption <= 0 || ElectricityPrice <= 0)
        {
            return -1;
        }
        else
        {
            return Math.Round(Consumption / 100 * Distance * ElectricityPrice, 2);
        }
    }

    public static double CalculateFullChargePrice(double batteryCapacity, double batteryLevel, double price)
    {
        return Math.Round(batteryCapacity / 100 * (100 - batteryLevel) * price, 2);
    }
}

