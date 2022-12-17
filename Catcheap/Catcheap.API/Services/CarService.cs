using Catcheap.API.Interfaces.IService;
using Catcheap.API.Interfaces.IRepository;
using Catcheap.API.Models.CarModels;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Catcheap.API.Services;

public class CarService : ICarService
{
    private readonly ICarRepository _carRepository;   
    private readonly ICarChargeService _chargeService;

    public CarService(ICarRepository carRepository, ICarChargeService chargeService)
    {
        _carRepository = carRepository;
        _chargeService = chargeService;
    }

    public void UpdateAfterJourney(Car car, CarJourney carJourney)
    {
        DecreaseExpectedRange(car, carJourney.Distance);
        DecreaseBatteryLevel(car, carJourney.Distance);
        IncreaseMileage(car, carJourney.Distance);
    
        _carRepository.UpdateCar(car);
    }

    public void UpdateAfterCharge(Car car, CarCharge carCharge)
    {
        IncreaseBatteryLevel(car, _chargeService.CalculateChargedKWh(carCharge));
        CalculateExpectedRange(car);

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

    public void CalculateExpectedRange(Car car)
    {
        car.ExpectedRange = Math.Round(car.BatteryCapacity * car.BatteryLevel * 0.01 / car.Consumption * 100, 2);
    }
}
