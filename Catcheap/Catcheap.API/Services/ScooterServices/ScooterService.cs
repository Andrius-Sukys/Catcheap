using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Interfaces.IService.IScooterServices;
using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Services.ScooterServices;

public class ScooterService : IScooterService
{
    private readonly IScooterRepository _scooterRepository;
    private readonly IScooterChargeService _chargeService;

    public ScooterService(IScooterRepository scooterRepository, IScooterChargeService chargeService)
    {
        _scooterRepository = scooterRepository;
        _chargeService = chargeService;
    }

    public void UpdateAfterJourney(Scooter scooter, ScooterJourney scooterJourney)
    {
        DecreaseExpectedRange(scooter, scooterJourney.Distance);
        DecreaseBatteryLevel(scooter, scooterJourney.Distance);

        _scooterRepository.UpdateScooter(scooter);
    }

    public void UpdateAfterCharge(Scooter scooter, ScooterCharge scooterCharge)
    {
        IncreaseBatteryLevel(scooter, _chargeService.CalculateChargedKWh(scooterCharge));
        CalculateExpectedRange(scooter);

        _scooterRepository.UpdateScooter(scooter);
    }

    public void DecreaseExpectedRange(Scooter scooter, double journeyDistance)
    {
        scooter.ExpectedRange -= journeyDistance;

        if (scooter.ExpectedRange < 0)
            scooter.ExpectedRange = 0;
    }

    public void DecreaseBatteryLevel(Scooter scooter, double journeyDistance)
    {
        scooter.BatteryLevel -= journeyDistance / 100 * scooter.Consumption / scooter.BatteryCapacity * 100;

        if (scooter.BatteryLevel < 0)
            scooter.BatteryLevel = 0;
    }

    public void IncreaseBatteryLevel(Scooter scooter, double chargedKW)
    {
        scooter.BatteryLevel += chargedKW / scooter.BatteryCapacity * 100;

        if (scooter.BatteryLevel > 100)
            scooter.BatteryLevel = 100;
    }

    public void CalculateExpectedRange(Scooter scooter)
    {
        scooter.ExpectedRange = Math.Round(scooter.BatteryCapacity * scooter.BatteryLevel * 0.01 / scooter.Consumption * 100, 2);

        if (scooter.WeightCapacity < scooter.Weight + scooter.WeightRider)
        {
            scooter.ExpectedRange /= (scooter.Weight + scooter.WeightRider) / scooter.WeightCapacity;
        }

        _scooterRepository.UpdateScooter(scooter);
    }
}
