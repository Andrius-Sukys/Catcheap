using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Interfaces.IService.IScooterServices;

namespace Catcheap.API.Services.ScooterServices;

public class ScooterStatsService : IScooterStatsService
{
    private readonly IScooterRepository _scooterRepository;
    private readonly IScooterChargeRepository _chargeRepository;
    private readonly IScooterJourneyRepository _journeyRepository;

    public ScooterStatsService(IScooterRepository scooterRepository, IScooterChargeRepository chargeRepository,
        IScooterJourneyRepository journeyRepository)
    {
        _scooterRepository = scooterRepository;
        _chargeRepository = chargeRepository;
        _journeyRepository = journeyRepository;
    }

    public double GetChargesCountSince(int scooterId, DateTime startDate)
    {
        return _chargeRepository.GetChargesOfAScooter(scooterId).Where(gcoas => gcoas.StartOfCharge > startDate).Count();
    }

    public double GetJourneysCountSince(int scooterId, DateTime startDate)
    {
        return _journeyRepository.GetJourneysOfAScooter(scooterId).Where(gjoas => gjoas.Date > startDate).Count();
    }

    public double GetJourneyDistanceSince(int scooterId, DateTime startDate)
    {
        return _journeyRepository.GetJourneysOfAScooter(scooterId)
                                 .Where(gcoas => gcoas.Date > startDate)
                                 .Select(gcoas => gcoas.Distance).Sum();
    }

    public double GetConsumptionSince(int scooterId, DateTime startDate)
    {
        return GetJourneyDistanceSince(scooterId, startDate) / 100 * _scooterRepository.GetScooter(scooterId).Consumption;
    }

    public double GetMoneySpentSince(int scooterId, DateTime startDate)
    {
        return _chargeRepository.GetChargesOfAScooter(scooterId)
                                .Where(gcoas => gcoas.StartOfCharge > startDate)
                                .Select(gcoas => gcoas.ChargingPrice).Sum();
    }
}
