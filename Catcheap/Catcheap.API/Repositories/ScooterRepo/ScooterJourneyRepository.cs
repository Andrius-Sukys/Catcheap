using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Repositories.ScooterRepo;

public class ScooterJourneyRepository : IScooterJourneyRepository
{
    private readonly DataContext _context;

    public ScooterJourneyRepository(DataContext context)
    {
        _context = context;
    }

    public bool ScooterJourneyExists(int scooterJourneyId)
    {
        return _context.ScooterJourneys.Any(sj => sj.Id == scooterJourneyId);
    }

    public bool CreateScooterJourney(ScooterJourney scooterJourney)
    {
        _context.Add(scooterJourney);
        return Save();
    }

    public bool DeleteScooterJourney(ScooterJourney scooterJourney)
    {
        _context.Remove(scooterJourney);
        return Save();
    }

    public bool DeleteScooterJourneys(List<ScooterJourney> scooterJourneys)
    {
        _context.RemoveRange(scooterJourneys);
        return Save();
    }

    public ScooterJourney GetScooterJourney(int scooterJourneyId)
    {
        return _context.ScooterJourneys.Where(sj => sj.Id == scooterJourneyId).FirstOrDefault();
    }

    public ICollection<ScooterJourney> GetScooterJourneys()
    {
        return _context.ScooterJourneys.OrderByDescending(sj => sj.Date).ToList();
    }

    public ICollection<ScooterJourney> GetJourneysOfAScooter(int scooterId)
    {
        return _context.ScooterJourneys.Where(sj => sj.Scooter.Id == scooterId).ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateScooterJourney(ScooterJourney scooterJourney)
    {
        _context.Update(scooterJourney);
        return Save();
    }
}
