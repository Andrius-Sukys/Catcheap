using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Interfaces.IService;

public interface ICarService
{
    void UpdateAfterJourney(Car car, double journeyDistance);

    void DecreaseExpectedRange(Car car, double journeyDistance);

    void DecreaseBatteryLevel(Car car, double journeyDistance);

    void IncreaseBatteryLevel(Car car, double chargedKWh);

    void IncreaseMileage(Car car, double journeyDistance);
}
