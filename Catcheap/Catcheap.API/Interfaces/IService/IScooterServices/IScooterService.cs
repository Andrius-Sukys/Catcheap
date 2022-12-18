using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Interfaces.IService.IScooterServices;

public interface IScooterService
{
    void UpdateAfterJourney(Scooter scooter, ScooterJourney scooterJourney);

    void UpdateAfterCharge(Scooter scooter, ScooterCharge scooterCharge);

    void CalculateExpectedRange(Scooter scooter);

    void DecreaseExpectedRange(Scooter scooter, double journeyDistance);

    void DecreaseBatteryLevel(Scooter scooter, double journeyDistance);

    void IncreaseBatteryLevel(Scooter scooter, double chargedKWh);

}
