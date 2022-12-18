using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Interfaces.IService.IScooterServices;

public interface IScooterChargeService
{
    TimeSpan CalculateDurationOfCharge(ScooterCharge scooterCharge);

    double CalculateChargedKWh(ScooterCharge scooterCharge);

    void CalculateChargePrice(ScooterCharge scooterCharge);
}
