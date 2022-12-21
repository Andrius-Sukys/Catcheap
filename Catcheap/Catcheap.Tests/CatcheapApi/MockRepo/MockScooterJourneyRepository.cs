using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Models.ScooterModels;


namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockScooterJourneyRepository : IScooterJourneyRepository
    {
        public bool ScooterJourneyExists(int scooterJourneyId)
        {
            return true;
        }

        public bool CreateScooterJourney(ScooterJourney scooterJourney)
        {
            return true;
        }

        public bool DeleteScooterJourney(ScooterJourney scooterJourney)
        {
            return true;
        }

        public bool DeleteScooterJourneys(List<ScooterJourney> scooterJourneys)
        {
            return true;
        }

        public ScooterJourney GetScooterJourney(int scooterJourneyId)
        {
            ScooterJourney scooterJourney = new ScooterJourney();
            scooterJourney.Id = scooterJourneyId;
            scooterJourney.Scooter = new Scooter();

            return scooterJourney;
        }

        public ICollection<ScooterJourney> GetScooterJourneys()
        {
            List<ScooterJourney> list = new List<ScooterJourney>();

            ScooterJourney scooterJourney = new ScooterJourney();
            scooterJourney.Scooter = new Scooter();

            list.Add(scooterJourney);

            return list;
        }

        public ICollection<ScooterJourney> GetJourneysOfAScooter(int scooterId)
        {
            List<ScooterJourney> list = new List<ScooterJourney>();

            ScooterJourney scooterJourney = new ScooterJourney();
            scooterJourney.Scooter = new Scooter();
            scooterJourney.Scooter.Id = scooterId;
            scooterJourney.Id = 10;
            scooterJourney.Date = new DateTime(2022, 12, 19, 12, 0, 0);
            scooterJourney.Distance = 100;

            list.Add(scooterJourney);

            return list;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateScooterJourney(ScooterJourney scooterJourney)
        {
            return true;
        }
    }
}
