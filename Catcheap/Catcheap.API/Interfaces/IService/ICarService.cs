using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Interfaces.IService;

public interface ICarService
{
    public void UpdateAfterJourney(Car car, CarJourney carJourney);

    public void UpdateAfterCharge(Car car, CarCharge carCharge);

    void CalculateExpectedRange(Car car);

    void DecreaseExpectedRange(Car car, double journeyDistance);

    void DecreaseBatteryLevel(Car car, double journeyDistance);

    void IncreaseBatteryLevel(Car car, double chargedKWh);

    void IncreaseMileage(Car car, double journeyDistance);
}
