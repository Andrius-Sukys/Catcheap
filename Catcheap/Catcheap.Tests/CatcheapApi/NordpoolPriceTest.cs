using Catcheap.API.Models.MiscModels;

namespace Catcheap.Tests.CatcheapApi
{
    public class NordpoolPriceTest
    {
        [Fact]
        public void CompareToTest()
        {
            NordpoolPrice price1 = new NordpoolPrice();
            NordpoolPrice price2 = new NordpoolPrice();

            price1.Price = 10;
            price2.Price = 1;

            Assert.Equal(1, price1.CompareTo(price2));
        }
    }
}
