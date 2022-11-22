using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Journeys_Classes;

namespace TestProject
{
    public class CatcheapCarTest
    {

        [Fact]
        public void SetAllTest()
        {
            Car car = new Car(new Lazy<Catcheap.Journeys>());

            car.SetAll("A", "B", "500", "82", "10,1", "69");

            Assert.True(car.Manufacturer == "A", "Incorrect Manufacturer");
            Assert.True(car.Model == "B", "Incorrect Model");
            Assert.True(car.Mileage == 500, "Incorrect Mileage");
            Assert.True(car.BatteryCapacity == 82, "Incorrect BatteryCapacity");
            Assert.True(car.Consumption == 10.1, "Incorrect Consumtion");
            Assert.True(car.BatteryLevel == 69, "Incorrect BatteryLevel");
            Assert.True(car.ExpectedRange == 560.2, "Incorrect ExpectedRange");
        }

        [Theory]
        [InlineData(500, 100, 600)]
        [InlineData(500, 0, 500)]
        [InlineData(0, 100, 100)]
        [InlineData(0, 0, 0)]
        public void IncreaseMileageTest(double mileage, double journeyDistance, double expectedResult)
        {
            var car = new Car(new Lazy<Catcheap.Journeys>());

            car.Mileage = mileage;

            car.IncreaseMileage(journeyDistance);

            Assert.True(car.Mileage == expectedResult);
        }

        [Theory]
        [InlineData(500, 10, 100, 100, 100, 100, 600, 90, 0)]
        [InlineData(0, 1, 1, 100, 0, 0, 0, 100, 0)]
        public void UpdateCarFieldsAfterJourneyTest(double mileage, double consumtion, double batteryCapacity, double batteryLevel, double expectedRange, double journeyDistance,
            double expectedMileage, double expectedBatteryLevel, double expectedExpectedRange)
        {
            var car = new Car(new Lazy<Catcheap.Journeys>());

            car.Mileage = mileage; car.Consumption = consumtion; car.BatteryCapacity = batteryCapacity; car.BatteryLevel = batteryLevel; car.ExpectedRange = expectedRange;

            car.UpdateCarFieldsAfterJourney(journeyDistance);

            Assert.True(car.Mileage == expectedMileage, "Incorrect ExpectedRange");
            Assert.True(car.BatteryLevel == expectedBatteryLevel, "Incorrect BatteryLevel");
            Assert.True(car.ExpectedRange == expectedExpectedRange, "Incorrect ExpectedRange");
        }
    }
}
