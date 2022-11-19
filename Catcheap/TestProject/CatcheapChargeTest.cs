using Catcheap.Models.Charge_Classes;

namespace TestProject
{
    public class CatcheapChargeTest
    {

        public TimeSpan GetTimeSpan(int h, int m, int s)
        {
            return new TimeSpan(h, m, s);
        }

        [Theory]
        [InlineData(10, 12, 2)]
        [InlineData(12, 10, 22)]
        [InlineData(10, 10, 0)]
        public void calculateDurationOfChargeTest(int Start, int End, int ExpectedResult)
        {
            Charge charge = new Charge(0, new TimeSpan(Start, 0, 0), new TimeSpan(End, 0, 0));

            Assert.True(charge.durationCharge == new TimeSpan(ExpectedResult, 0, 0));
        }

        [Theory]
        [InlineData(0, 10, 10, 0)]
        [InlineData(1000, 10, 12, 2)]
        public void calculateChargedKWhTest(double ChargingPower, int Start, int End, double ExpectedResult)
        {
            Charge charge = new Charge(ChargingPower, new TimeSpan(Start, 0, 0), new TimeSpan(End, 0, 0));

            Assert.True(charge.chargedKWh == ExpectedResult);
        }

    }
}
