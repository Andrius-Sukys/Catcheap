using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Interfaces.IRepository.IScooterRepo;

public interface IScooterJourneyRepository
{
    ICollection<ScooterJourney> GetScooterJourneys();

    ICollection<ScooterJourney> GetJourneysOfAScooter(int scooterId);

    ScooterJourney GetScooterJourney(int scooterJourneyId);

    bool ScooterJourneyExists(int scooterJourneyId);

    bool CreateScooterJourney(ScooterJourney scooterJourney);

    bool UpdateScooterJourney(ScooterJourney scooterJourney);

    bool DeleteScooterJourney(ScooterJourney scooterJourney);

    bool DeleteScooterJourneys(List<ScooterJourney> scooterJourneys);

    bool Save();
}
