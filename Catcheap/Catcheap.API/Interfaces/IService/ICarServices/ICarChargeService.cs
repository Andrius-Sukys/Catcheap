using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Interfaces.IService.ICarServices;

public interface ICarChargeService
{
    TimeSpan CalculateDurationOfCharge(CarCharge carCharge);

    double CalculateChargedKWh(CarCharge carCharge);

    void CalculateChargePrice(CarCharge carCharge);
}
