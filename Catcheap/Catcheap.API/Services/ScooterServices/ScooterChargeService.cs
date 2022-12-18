using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Interfaces.IService.IScooterServices;
using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Services.ScooterServices;

public class ScooterChargeService : IScooterChargeService
{
    private readonly IScooterChargeRepository _chargeRepository;
    private readonly INordpoolPriceRepository _nordpoolPriceRepository;

    public ScooterChargeService(IScooterChargeRepository chargeRepository,
        INordpoolPriceRepository nordpoolPriceRepository)
    {
        _chargeRepository = chargeRepository;
        _nordpoolPriceRepository = nordpoolPriceRepository;
    }

    public TimeSpan CalculateDurationOfCharge(ScooterCharge scooterCharge)
    {
        return scooterCharge.EndOfCharge.Subtract(scooterCharge.StartOfCharge);
    }

    public double CalculateChargedKWh(ScooterCharge scooterCharge)
    {
        TimeSpan durationOfCharge = CalculateDurationOfCharge(scooterCharge);

        return scooterCharge.ChargingPower * durationOfCharge.TotalHours;
    }

    public void CalculateChargePrice(ScooterCharge scooterCharge)
    {
        scooterCharge.ChargingPrice = CalculateChargedKWh(scooterCharge) * _nordpoolPriceRepository.GetNordpoolPriceByDate(scooterCharge.StartOfCharge).Price;

        _chargeRepository.UpdateScooterCharge(scooterCharge);
    }
}
