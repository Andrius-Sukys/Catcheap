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
            calc.distance = value;
            calc.consumption = value;
            calc.electricityPrice = value;

            Double ActualResult = calc.calculatePrice();

            Assert.True(ActualResult == value, "Bad");
        }

        [Fact]
        public void calculateFullChargePriceTest()
        {

            double ActualResult = calc.calculateFullChargePrice(100, 50, 0.1);

            Assert.True(ActualResult == 5, "Bad");
        }
    }
}
