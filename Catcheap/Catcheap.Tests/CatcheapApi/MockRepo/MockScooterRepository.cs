using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Models.ScooterModels;


namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockScooterRepository :  IScooterRepository
    {
        public Scooter GetScooter(int scooterId)
        {
            Scooter scooter = new Scooter();
            scooter.Id = scooterId;
            scooter.Consumption = 10;
            return scooter;
        }

        public bool ScooterExists(int scooterId)
        {
            return true;
        }

        public ICollection<Scooter> GetScooters()
        {
            List<Scooter> list = new List<Scooter>();
            list.Add(new Scooter());
            return list;
        }

        public bool CreateScooter(Scooter scooter)
        {
            return true;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateScooter(Scooter scooter)
        {
            return true;
        }

        public bool DeleteScooter(Scooter scooter)
        {
            return true;
        }
    }
}
