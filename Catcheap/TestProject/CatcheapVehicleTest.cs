using Catcheap.Models.Vehicles_Classes;

namespace TestProject
{
    public class CatcheapVehicleTest
    {
        [Theory]
        [InlineData(10, 10, 0)]
        [InlineData(0, 10, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(100, 10, 90)]
        public void DecreaseExpectedRangeTest(double expectedRange, double journeyDistance, double expectedResult)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.ExpectedRange = expectedRange;

            vehicle.DecreaseExpectedRange(journeyDistance);

            Assert.True(vehicle.ExpectedRange == expectedResult);
        }

        [Theory]
        [InlineData(100, 0, 0, 1, 100)]
        [InlineData(100, 100, 10, 100, 90)]
        [InlineData(100, 100, 90, 100, 10)]
        [InlineData(10, 100, 90, 100, 0)]
        public void DecreaseBatteryLevelTest(double BatteryLevel, double JourneyDistance, double Consumption, double BatteryCapacity, double expectedResult)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.BatteryLevel = BatteryLevel;

            vehicle.DecreaseBatteryLevel(JourneyDistance, Consumption, BatteryCapacity);

            Assert.True(vehicle.BatteryLevel == expectedResult);
        }

        [Theory]
        [InlineData(0,100,100,100)]
        [InlineData(100,100,100,100)]
        [InlineData(50,100,30,80)]
        public void IncreaseBatteryLevelTest(double BatteryLevel, double BatteryCapacity, double ChargedKWh, double expectedResult)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.BatteryLevel = BatteryLevel; vehicle.BatteryCapacity = BatteryCapacity;

            vehicle.IncreaseBatteryLevel(ChargedKWh);

            Assert.True(vehicle.BatteryLevel == expectedResult);
        }

        [Theory]
        [InlineData(100, 100, 10, 100, 100, 90, 0)]
        [InlineData(0, 100, 10, 100, 100, 0, 0)]
        [InlineData(50, 100, 10, 100, 100, 40, 0)]
        [InlineData(100, 100, 10, 100, 150, 90, 50)]
        [InlineData(100, 0, 10, 100, 100, 100, 100)]
        public void UpdateFieldsAfterJourneyTest(double BatteryLevel, double JourneyDistance, double Consumption, double BatteryCapacity, double ExpectedRange,
            double expectedBatteryLevel, double expectedExpectedRange)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.BatteryLevel = BatteryLevel; vehicle.BatteryCapacity = BatteryCapacity; vehicle.Consumption = Consumption; vehicle.ExpectedRange = ExpectedRange;

            vehicle.UpdateFieldsAfterJourney(JourneyDistance);

            Assert.True(vehicle.BatteryLevel == expectedBatteryLevel, "incorrect battery level");
            Assert.True(vehicle.ExpectedRange == expectedExpectedRange, "incorrect expected range");
        }

        [Theory]
        [InlineData(100, 100, 10, 10, 100, 1000)]
        [InlineData(50, 100, 10, 10, 60, 600)]
        [InlineData(0, 100, 10, 0, 0, 0)]
        [InlineData(0, 1, 0, 0, 0, 0)]
        public void UpdateFieldsAfterChargingTest(double BatteryLevel, double BatteryCapacity, double Consumption, double ChargedKWh,
            double expectedBatteryLevel, double expectedExpectedRange)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.BatteryLevel = BatteryLevel; vehicle.BatteryCapacity = BatteryCapacity; vehicle.Consumption = Consumption;

            vehicle.UpdateFieldsAfterCharging(ChargedKWh);

            Assert.True(vehicle.BatteryLevel == expectedBatteryLevel, "incorrect battery level");
            Assert.True(vehicle.ExpectedRange == expectedExpectedRange, "incorrect expected range");
        }

        [Theory]
        [InlineData(100, 100, 10, 1000)]
        [InlineData(0, 100, 10, 0)]
        [InlineData(100, 100, 0, 0)]
        public void CalculateExpectedRangeTest(double BatteryLevel, double BatteryCapacity, double Consumption, double ExpectedResult)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.BatteryLevel = BatteryLevel; vehicle.BatteryCapacity = BatteryCapacity; vehicle.Consumption = Consumption;

            Assert.True(vehicle.CalculateExpectedRange() == ExpectedResult);
        }

    }
}
