using Catcheap_API.Data;
using Catcheap_API.Interfaces.IRepository;
using Catcheap_API.Logs;
using Catcheap_API.Models.CarModels;

namespace Catcheap_API.Repositories.CarRepo;

public class CarJourneyRepository : ICarJourneyRepository
{
    private readonly DataContext _context;

    public CarJourneyRepository(DataContext context)
    {
        _context = context;
    }

    public bool CarJourneyExists(int carJourneyId)
    {
        return _context.CarJourneys.Any(cj => cj.Id == carJourneyId);
    }

    public bool CreateCarJourney(CarJourney carJourney)
    {
        _context.Add(carJourney);
        return Save();
    }

    public bool DeleteCarJourney(CarJourney carJourney)
    {
        _context.Remove(carJourney);
        return Save();
    }

    public bool DeleteCarJourneys(List<CarJourney> carJourneys)
    {
        _context.RemoveRange(carJourneys);
        return Save();
    }

    public CarJourney GetCarJourney(int carJourneyId)
    {
        return _context.CarJourneys.Where(cj => cj.Id == carJourneyId).FirstOrDefault();
    }

    public ICollection<CarJourney> GetCarJourneys()
    {
        return _context.CarJourneys.OrderByDescending(cj => cj.Date).ToList();
    }

    public ICollection<CarJourney> GetJourneysOfACar(int carId)
    {
        return _context.CarJourneys.Where(cj => cj.Car.Id == carId).ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateCarJourney(CarJourney carJourney)
    {
        _context.Update(carJourney);
        return Save();
    }
}
