using Catcheap.API.Models.CarModels;

namespace Catcheap.API.Interfaces.IRepository;

public interface ICarJourneyRepository
{
    ICollection<CarJourney> GetCarJourneys();

    ICollection<CarJourney> GetJourneysOfACar(int carId);

    CarJourney GetCarJourney(int carJourneyId);

    bool CarJourneyExists(int carJourneyId);

    bool CreateCarJourney(CarJourney carJourney);

    bool UpdateCarJourney(CarJourney carJourney);

    bool DeleteCarJourney(CarJourney carJourney);

    bool DeleteCarJourneys(List<CarJourney> carJourneys);

    bool Save();
}
