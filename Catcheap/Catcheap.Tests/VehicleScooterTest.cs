using Catcheap.Models.Journeys_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;

namespace TestProject
{
    public class VehicleScooterTest
    {

        [Fact]
        public void SetAllTest()
        {
            var vehicleScooter = new VehicleScooter(new Catcheap.Journeys(new List<Journey>(), new List<Journey>()));

            vehicleScooter.SetAll("A", "B", "100", "10", "50", "0", "0", "0", "1", "1");

            Assert.Equal("A", vehicleScooter.Manufacturer);
            Assert.Equal("B", vehicleScooter.Model);
            Assert.Equal(100, vehicleScooter.BatteryCapacity);
            Assert.Equal(10, vehicleScooter.Consumption);
            Assert.Equal(50, vehicleScooter.BatteryLevel);
            Assert.Equal(0, vehicleScooter.Weight);
            Assert.Equal(0, vehicleScooter.WeightCapacity);
            Assert.Equal(0, vehicleScooter.WeightRider);
            Assert.Equal(1, vehicleScooter.AverageSpeed);
            Assert.Equal(1, vehicleScooter.TopSpeed);
            Assert.Equal(0, vehicleScooter.ExpectedRange);

        }
    }
}
