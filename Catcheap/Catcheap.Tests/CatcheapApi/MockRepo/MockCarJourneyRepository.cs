

using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Models.CarModels;

namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockCarJourneyRepository : ICarJourneyRepository
    {

        public bool CarJourneyExists(int carJourneyId)
        {
            return true;
        }

        public bool CreateCarJourney(CarJourney carJourney)
        {
            return true;
        }

        public bool DeleteCarJourney(CarJourney carJourney)
        {
            return true;
        }

        public bool DeleteCarJourneys(List<CarJourney> carJourneys)
        {
            return true;
        }

        public CarJourney GetCarJourney(int carJourneyId)
        {
            CarJourney carJourney = new CarJourney();
            carJourney.Id = carJourneyId;
            carJourney.Car = new Car();

            return carJourney;
        }

        public ICollection<CarJourney> GetCarJourneys()
        {
            List<CarJourney> list = new List<CarJourney>();

            CarJourney carJourney = new CarJourney();
            carJourney.Car = new Car();

            list.Add(carJourney);

            return list;
        }

        public ICollection<CarJourney> GetJourneysOfACar(int carId)
        {
            List<CarJourney> list = new List<CarJourney>();

            CarJourney carJourney = new CarJourney();
            carJourney.Id = 10;
            carJourney.Car = new Car();
            carJourney.Car.Id = carId;
            carJourney.Date = new DateTime(2022, 12, 19, 12, 0, 0);
            carJourney.Distance = 100;

            list.Add(carJourney);

            return list;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateCarJourney(CarJourney carJourney)
        {
            return true;
        }
    }
}
