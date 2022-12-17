using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository;
using Catcheap.API.Models.MiscModels;

namespace Catcheap.API.Repositories.MiscRepo;

public class ChargingStationRepository : IChargingStationRepository
{
    private DataContext _context;

    public ChargingStationRepository(DataContext context)
    {
        _context = context;
    }

    public bool ChargingStationExists(int chargingStationId)
    {
        return _context.ChargingStations.Any(cs => cs.Id == chargingStationId);
    }

    public bool CreateChargingStation(ChargingStation chargingStation)
    {
        _context.Add(chargingStation);
        return Save();
    }

    public bool DeleteChargingStation(ChargingStation chargingStation)
    {
        _context.Remove(chargingStation);
        return Save();
    }

    public ChargingStation GetChargingStation(int chargingStationId)
    {
        return _context.ChargingStations.Where(cs => cs.Id == chargingStationId).FirstOrDefault();
    }

    public ICollection<ChargingStation> GetChargingStations()
    {
        return _context.ChargingStations.ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateChargingStation(ChargingStation chargingStation)
    {
        _context.Update(chargingStation);
        return Save();
    }
}
