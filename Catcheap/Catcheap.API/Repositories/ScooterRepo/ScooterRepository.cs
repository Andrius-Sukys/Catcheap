using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository;
using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Repositories.ScooterRepo;

public class ScooterRepository : IScooterRepository
{
    private readonly DataContext _context;

    public ScooterRepository(DataContext context)
    {
        _context = context;
    }

    public Scooter GetScooter(int scooterId)
    {
        return _context.Scooters.Where(s => s.Id == scooterId).FirstOrDefault();
    }

    public bool ScooterExists(int scooterId)
    {
        return _context.Scooters.Any(s => s.Id == scooterId);
    }

    public ICollection<Scooter> GetScooters()
    {
        return _context.Scooters.OrderBy(s => s.Id).ToList();
    }

    public bool CreateScooter(Scooter scooter)
    {
        _context.Add(scooter);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateScooter(Scooter scooter)
    {
        _context.Update(scooter);
        return Save();
    }

    public bool DeleteScooter(Scooter scooter)
    {
        _context.Remove(scooter);
        return Save();
    }
}
