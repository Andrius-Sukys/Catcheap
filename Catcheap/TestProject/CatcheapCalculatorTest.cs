using Catcheap.Models.Calculator_Classes;
using Xunit;

namespace TestProject
{
    public class CatcheapCalculatorTest
    {
        Calculator calc = new Calculator();

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void calculatePriceTest(double value)
        {
            calc.Distance = value;
            calc.Consumption = value;
            calc.ElectricityPrice = value;

            Double ActualResult = calc.CalculatePrice();

            Assert.True(ActualResult == value, "Bad");
        }

        [Fact]
        public void calculateFullChargePriceTest()
        {

            double ActualResult = Calculator.CalculateFullChargePrice(100, 50, 0.1);

            Assert.True(ActualResult == 5, "Bad");
        }
    }
}
