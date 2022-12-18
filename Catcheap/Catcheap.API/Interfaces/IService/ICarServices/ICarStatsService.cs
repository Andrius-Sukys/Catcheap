using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Interfaces.IService.ICarServices;

public interface ICarStatsService
{
    double GetJourneyDistanceSince(int carId, DateTime startDate);

    double GetMoneySpentSince(int carId, DateTime startDate);

    double GetJourneysCountSince(int carId, DateTime startDate);

    double GetChargesCountSince(int carId, DateTime startDate);

    double GetConsumptionSince(int carId, DateTime startDate);

}
