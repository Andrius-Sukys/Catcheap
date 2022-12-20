using Catcheap.API.Models.CarModels;


namespace Catcheap.Tests.CatcheapApi
{
    public class CarChargeTest
    {
        [Fact]
        public void CompareToTest()
        {
            CarCharge charge1 = new CarCharge();
            CarCharge charge2 = new CarCharge();

            charge1.StartOfCharge = new DateTime(2022,12,13,12,0,0);
            charge2.StartOfCharge = new DateTime(2022, 12, 12, 12, 0, 0);

            Assert.Equal(1, charge1.CompareTo(charge2));
        }
    }
}
