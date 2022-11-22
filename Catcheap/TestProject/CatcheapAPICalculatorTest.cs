using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using CatcheapAPI.Models.Vehicles_Classes.Cars_Classes;

namespace TestProject
{
    public class CatcheapAPICalculatorTest
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public CatcheapAPICalculatorTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task CalculateFullChargePriceTest()
        {
            var client = _factory.CreateClient();

            Car car = new Car();

            car.BatteryCapacity = 100;
            car.BatteryLevel = 0;
            car.Manufacturer = "asd";
            car.Model = "sad";
            car.journeys = null;

            var response = await client.PutAsJsonAsync("api/Calculator", car);

            response.EnsureSuccessStatusCode();
            Assert.Equal(20, await response.Content.ReadAsAsync<Double>());
        }

    }
}
