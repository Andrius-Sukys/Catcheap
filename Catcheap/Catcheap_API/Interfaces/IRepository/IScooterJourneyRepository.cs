using Catcheap_API.Models.ScooterModels;

namespace Catcheap_API.Interfaces.IRepository;

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
