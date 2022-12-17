using Catcheap.Models.Price_Classes;

namespace TestProject
{
    public class CatcheapDayPriceTest
    {

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(23)]
        public void GetHourPriceTest(int i)
        {

            String[] price = new String[25];

            price[0] = "Labas";

            for (int j = 1; j < 25; j++)
            {
                price[j] = (j * 1000).ToString();
            }

            var dayPrice = new DayPrice(new DateOnly(2002,2,6), price);

            Assert.True(dayPrice.GetHourPrice(i) == (i+1));

        }

        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(23)]
        public void GetDaysCheapestPriceAndHourStringTest(int currentHour)
        {

            String[] price = new String[25];

            price[0] = "Labas";

            for (int j = 1; j < 25; j++)
            {
                price[j] = (j * 1000).ToString();
            }

            var dayPrice = new DayPrice(new DateOnly(2002, 2, 6), price);

            Assert.Equal((currentHour + 1).ToString() + " €/kWh\n" + currentHour.ToString() + ":00 - " + (currentHour + 1) % 24 + ":00",
                dayPrice.GetDaysCheapestPriceAndHourString(currentHour));

        }

        [Fact]
        public void ToStringTest()
        {
            String[] price = new String[25];

            price[0] = "Labas";

            for (int j = 1; j < 25; j++)
            {
                price[j] = (j * 1000).ToString();
            }

            var dayPrice = new DayPrice(new DateOnly(2002, 2, 6), price);

            string expectedResult = "2002-02-06\n";

            for (int i = 0; i < 24; i++)
            {
                expectedResult += i + ":00 | " + (i + 1) + " €/kWh\n";
            }

            Assert.Equal(expectedResult, dayPrice.ToString());
        }

    }
}
