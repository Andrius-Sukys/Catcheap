using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Interfaces.IService.ICarServices;
using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Services.CarServices;

public class CarChargeService : ICarChargeService
{
    private readonly ICarChargeRepository _chargeRepository;
    private readonly INordpoolPriceRepository _nordpoolPriceRepository;

    public CarChargeService(ICarChargeRepository chargeRepository,
        INordpoolPriceRepository nordpoolPriceRepository)
    {
        _chargeRepository = chargeRepository;
        _nordpoolPriceRepository = nordpoolPriceRepository;
    }

    public TimeSpan CalculateDurationOfCharge(CarCharge carCharge)
    {
        return carCharge.EndOfCharge.Subtract(carCharge.StartOfCharge);
    }

    public double CalculateChargedKWh(CarCharge carCharge)
    {
        TimeSpan durationOfCharge = CalculateDurationOfCharge(carCharge);

        return carCharge.ChargingPower * durationOfCharge.TotalHours;
    }

    public void CalculateChargePrice(CarCharge carCharge)
    {
        carCharge.ChargingPrice = CalculateChargedKWh(carCharge) * _nordpoolPriceRepository.GetNordpoolPriceByDate(carCharge.StartOfCharge).Price;

        _chargeRepository.UpdateCarCharge(carCharge);
    }
}
