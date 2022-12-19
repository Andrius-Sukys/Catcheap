using Catcheap.API.Models.ScooterModels;
using Catcheap.API.Services.ScooterServices;
using Catcheap.Tests.CatcheapApi.MockRepo;

namespace Catcheap.Tests.CatcheapApi
{
    public class ScooterServiceTest
    {
        [Fact]
        public void DecreaseExpectedRangeTest()
        {
            Scooter scooter = new Scooter();
            scooter.ExpectedRange = 100;

            ScooterService service = new ScooterService(new MockScooterRepository(), new ScooterChargeService(new MockScooterChargeRepository(), new MockNordpoolPriceRepository()));

            service.DecreaseExpectedRange(scooter, 50);

            Assert.Equal(50, scooter.ExpectedRange);
        }

        [Fact]
        public void DecreaseBatteryLevelTest()
        {
            Scooter scooter = new Scooter();
            scooter.BatteryLevel = 100;
            scooter.Consumption = 10;
            scooter.BatteryCapacity = 100;

            ScooterService service = new ScooterService(new MockScooterRepository(), new ScooterChargeService(new MockScooterChargeRepository(), new MockNordpoolPriceRepository()));

            service.DecreaseBatteryLevel(scooter, 50);

            Assert.Equal(95, scooter.BatteryLevel);
        }

        [Fact]
        public void IncreaseBatteryLevelTest()
        {
            Scooter scooter = new Scooter();
            scooter.BatteryLevel = 10;
            scooter.BatteryCapacity = 100;

            ScooterService service = new ScooterService(new MockScooterRepository(), new ScooterChargeService(new MockScooterChargeRepository(), new MockNordpoolPriceRepository()));

            service.IncreaseBatteryLevel(scooter, 50);

            Assert.Equal(60, scooter.BatteryLevel);
        }

        [Fact]
        public void UpdateAfterJourneyTest()
        {
            Scooter scooter = new Scooter();
            scooter.ExpectedRange = 100;
            scooter.BatteryLevel = 100;
            scooter.Consumption = 10;
            scooter.BatteryCapacity = 100;
            ScooterService service = new ScooterService(new MockScooterRepository(), new ScooterChargeService(new MockScooterChargeRepository(), new MockNordpoolPriceRepository()));
            ScooterJourney scooterJourney = new ScooterJourney();
            scooterJourney.Distance = 50;

            service.UpdateAfterJourney(scooter, scooterJourney);

            Assert.Equal(50, scooter.ExpectedRange);
            Assert.Equal(95, scooter.BatteryLevel);
        }

        [Fact]
        public void UpdateAfterChargeTest()
        {
            Scooter scooter = new Scooter();
            scooter.ExpectedRange = 100;
            scooter.BatteryLevel = 10;
            scooter.Consumption = 10;
            scooter.BatteryCapacity = 100;
            ScooterService service = new ScooterService(new MockScooterRepository(), new ScooterChargeService(new MockScooterChargeRepository(), new MockNordpoolPriceRepository()));
            ScooterCharge scooterCharge = new ScooterCharge();
            scooterCharge.StartOfCharge = new DateTime(2022, 12, 19, 12, 0, 0);
            scooterCharge.EndOfCharge = new DateTime(2022, 12, 19, 13, 0, 0);
            scooterCharge.ChargingPower = 10;


            service.UpdateAfterCharge(scooter, scooterCharge);

            Assert.Equal(200, scooter.ExpectedRange);
            Assert.Equal(20, scooter.BatteryLevel);
        }

        [Fact]
        public void CalculateExpectedRangeTest()
        {
            Scooter scooter = new Scooter();
            scooter.BatteryLevel = 100;
            scooter.Consumption = 100;
            scooter.BatteryCapacity = 100;
            ScooterService service = new ScooterService(new MockScooterRepository(), new ScooterChargeService(new MockScooterChargeRepository(), new MockNordpoolPriceRepository()));

            service.CalculateExpectedRange(scooter);

            Assert.Equal(100, scooter.ExpectedRange);
        }
    }
}
