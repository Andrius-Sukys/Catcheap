using Catcheap_API.Models.ScooterModels;

namespace Catcheap_API.Interfaces.IRepository;

public interface IScooterRepository
{
    ICollection<Scooter> GetScooters();

    Scooter GetScooter(int scooterId);

    bool ScooterExists(int scooterId);

    bool CreateScooter(Scooter scooter);

    bool UpdateScooter(Scooter scooter);

    bool DeleteScooter(Scooter scooter);

    bool Save();
}
