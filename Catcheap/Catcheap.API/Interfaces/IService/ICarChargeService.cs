using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Interfaces.IService;

public interface ICarChargeService
{
    public TimeSpan CalculateDurationOfCharge(CarCharge carCharge);

    public double CalculateChargedKWh(CarCharge carCharge);
}
