using Catcheap.Models.ToStringConverter_Classes;
using Catcheap.Models.Vehicles_Classes.Cars_Classes;
using Catcheap.Models.Vehicles_Classes.Other_Classes;
using Catcheap.Models.Vehicles_Classes;

namespace TestProject
{
    public class CatcheapToStringTest
    {

        [Fact]
        public void CarStringTest()
        {
            var carString = new CarString();
            var car = new Car(new Lazy<Catcheap.Journeys>());

            car.SetAll("A", "B", "500", "100", "10", "50");

            string expectedResult = "Manufacturer: A\n" +
                "Model: B\n" +
                "Mileage: 500 km\n" +
                "Expected range: 500 km\n" +
                "Battery size: 100 kWh\n" +
                "Consumption rate: 10 kWh/100 km\n" +
                "Battery level: 50 %\n";



            Assert.Equal(expectedResult, carString.ToString(car));
        }

        [Fact]
        public void ElectricScooterStringTest()
        {
            var electricScooterString = new ElectricScooterString();
            var vehicleScooter = new VehicleScooter(new Lazy<Catcheap.Journeys>());

            vehicleScooter.SetAll("A", "B", "100", "10", "50", "0", "0", "0", "1", "1");

            string expectedResult = "Manufacturer: A\n" +
                "Model: B\n" +
                "Expected range: 0 km\n" +
                "Battery size: 100 kWh\n" +
                "Consumption rate: 10 kWh/100 km\n" +
                "Battery level: 50 %\n" +
                "Weight: 0 kg\n" +
                "Weight capacity: 0 kg\n" +
                "Rider's weight: 0 kg\n";



            Assert.Equal(expectedResult, electricScooterString.ToString(vehicleScooter));
        }

        [Fact]
        public void VehicleStringTest()
        {
            var vehicleString = new VehicleString();
            var vehicle = new Vehicle();

            vehicle.Manufacturer = "A"; vehicle.Model = "B"; vehicle.ExpectedRange = 500; vehicle.BatteryCapacity = 100;
            vehicle.Consumption = 10; vehicle.BatteryLevel = 50;

            string expectedResult = "Manufacturer: A\n" +
                "Model: B\n" +
                "Expected range: 500 km\n" +
                "Battery size: 100 kWh\n" +
                "Consumption rate: 10 kWh/100 km\n" +
                "Battery level: 50 %\n";



            Assert.Equal(expectedResult, vehicleString.ToString(vehicle));
        }

    }
}
