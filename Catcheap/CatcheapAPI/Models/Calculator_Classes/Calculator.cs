namespace CatcheapAPI.Models.Calculator_Classes
{
    public class Calculator
    {
        public double calculateFullChargePrice(double batteryCapacity, double batteryLevel, double price)
        {
            return Math.Round((batteryCapacity / 100 * (100 - batteryLevel) * price), 2);
        }
    }
}
