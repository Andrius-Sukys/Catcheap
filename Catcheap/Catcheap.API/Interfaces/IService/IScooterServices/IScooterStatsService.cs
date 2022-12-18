namespace Catcheap.API.Interfaces.IService.IScooterServices;

public interface IScooterStatsService
{
    double GetJourneyDistanceSince(int scooterId, DateTime startDate);

    double GetMoneySpentSince(int scooterId, DateTime startDate);

    double GetJourneysCountSince(int scooterId, DateTime startDate);

    double GetChargesCountSince(int scooterId, DateTime startDate);

    double GetConsumptionSince(int scooterId, DateTime startDate);
}
