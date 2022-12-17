using Catcheap.API.Interfaces.IService;
using Catcheap_API.Interfaces.IRepository;
using Catcheap_API.Models.CarModels;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Catcheap_API.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;   

    public CarService(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }

    public void UpdateAfterJourney(Car car, double journeyDistance)
    {
        DecreaseExpectedRange(car, journeyDistance);
        DecreaseBatteryLevel(car, journeyDistance);
        IncreaseMileage(car, journeyDistance);
    
        _carRepository.UpdateCar(car);
    }

    public void DecreaseExpectedRange(Car car, double journeyDistance)
    {
        car.ExpectedRange -= journeyDistance;

        if(car.ExpectedRange < 0)
            car.ExpectedRange = 0;
    }

    public void DecreaseBatteryLevel(Car car, double journeyDistance)
    {
        car.BatteryLevel -= (journeyDistance / 100) * car.Consumption / car.BatteryCapacity * 100;

        if (car.BatteryLevel < 0)
            car.BatteryLevel = 0;
    }

    public void IncreaseBatteryLevel(Car car, double chargedKWh)
    {
        car.BatteryLevel += chargedKWh / car.BatteryCapacity * 100;

        if(car.BatteryLevel > 100)
            car.BatteryLevel = 100;
    }

    public void IncreaseMileage(Car car, double journeyDistance)
    {
        car.Mileage += journeyDistance;
    }

}
