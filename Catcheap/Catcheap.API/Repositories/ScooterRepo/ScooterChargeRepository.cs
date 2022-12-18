using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Repositories.ScooterRepo;

public class ScooterChargeRepository : IScooterChargeRepository
{
    private readonly DataContext _context;

    public ScooterChargeRepository(DataContext context)
    {
        _context = context;
    }

    public bool ScooterChargeExists(int scooterChargeId)
    {
        return _context.ScooterCharges.Any(sc => sc.Id == scooterChargeId);
    }

    public bool CreateScooterCharge(ScooterCharge scooterCharge)
    {
        _context.Add(scooterCharge);
        return Save();
    }

    public bool DeleteScooterCharge(ScooterCharge scooterCharge)
    {
        _context.Remove(scooterCharge);
        return Save();
    }

    public bool DeleteScooterCharges(List<ScooterCharge> scooterCharges)
    {
        _context.RemoveRange(scooterCharges);
        return Save();
    }

    public ScooterCharge GetScooterCharge(int scooterChargeId)
    {
        return _context.ScooterCharges.Where(sc => sc.Id == scooterChargeId).FirstOrDefault();
    }

    public ICollection<ScooterCharge> GetScooterCharges()
    {
        return _context.ScooterCharges.OrderByDescending(sc => sc.EndOfCharge).ToList();
    }

    public ICollection<ScooterCharge> GetChargesOfAScooter(int scooterId)
    {
        return _context.ScooterCharges.Where(sc => sc.Scooter.Id == scooterId).ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateScooterCharge(ScooterCharge scooterCharge)
    {
        _context.Update(scooterCharge);
        return Save();
    }
}
