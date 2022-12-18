using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Interfaces.IService.ICarServices;

namespace Catcheap.API.Services.CarServices;

public class CarStatsService : ICarStatsService
{
    private readonly ICarRepository _carRepository;
    private readonly ICarChargeRepository _chargeRepository;
    private readonly ICarJourneyRepository _journeyRepository;

    public CarStatsService(ICarRepository carRepository, ICarChargeRepository chargeRepository,
        ICarJourneyRepository journeyRepository)
    {
        _carRepository = carRepository;
        _chargeRepository = chargeRepository;
        _journeyRepository = journeyRepository;
    }

    public double GetChargesCountSince(int carId, DateTime startDate)
    {
        return _chargeRepository.GetChargesOfACar(carId).Where(gcoac => gcoac.StartOfCharge > startDate).Count();
    }

    public double GetJourneysCountSince(int carId, DateTime startDate)
    {
        return _journeyRepository.GetJourneysOfACar(carId).Where(gjoac => gjoac.Date > startDate).Count();
    }

    public double GetJourneyDistanceSince(int carId, DateTime startDate)
    {
        return _journeyRepository.GetJourneysOfACar(carId)
                                 .Where(gcoac => gcoac.Date > startDate)
                                 .Select(gcoac => gcoac.Distance).Sum();
    }

    public double GetConsumptionSince(int carId, DateTime startDate)
    {
        return GetJourneyDistanceSince(carId, startDate) / 100 * _carRepository.GetCar(carId).Consumption;
    }

    public double GetMoneySpentSince(int carId, DateTime startDate)
    {
        return _chargeRepository.GetChargesOfACar(carId)
                                .Where(gcoac => gcoac.StartOfCharge > startDate)
                                .Select(gcoac => gcoac.ChargingPrice).Sum();
    }
}
