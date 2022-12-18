using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Interfaces.IService.ICarServices;

public interface ICarService
{
    void UpdateAfterJourney(Car car, CarJourney carJourney);

    void UpdateAfterCharge(Car car, CarCharge carCharge);

    void CalculateExpectedRange(Car car);

    void DecreaseExpectedRange(Car car, double journeyDistance);

    void DecreaseBatteryLevel(Car car, double journeyDistance);

    void IncreaseBatteryLevel(Car car, double chargedKWh);

    void IncreaseMileage(Car car, double journeyDistance);
}
