using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository;
using Catcheap.API.Models.MiscModels;

namespace Catcheap.API.Repositories.MiscRepo;

public class NordpoolPriceRepository : INordpoolPriceRepository
{
    private readonly DataContext _context;

    public NordpoolPriceRepository(DataContext context)
    {
        _context = context;
    }

    public bool NordpoolPriceExists(int nordpoolPriceId)
    {
        return _context.NordpoolPrices.Any(np => np.Id == nordpoolPriceId);
    }

    public bool NordpoolPriceExistsByDate(DateTime nordpoolPriceDateTime)
    {
        return _context.NordpoolPrices.Any(np => np.DateAndTime.Hour == nordpoolPriceDateTime.Hour);
    }

    public bool CreateNordpoolPrice(NordpoolPrice nordpoolPrice)
    {
        _context.Add(nordpoolPrice);
        return Save();
    }

    public bool DeleteNordpoolPrice(NordpoolPrice nordpoolPrice)
    {
        _context.Remove(nordpoolPrice);
        return Save();
    }

    public NordpoolPrice GetNordpoolPrice(int nordpoolPriceId)
    {
        return _context.NordpoolPrices.Where(np => np.Id == nordpoolPriceId).FirstOrDefault();
    }

    public NordpoolPrice GetNordpoolPriceByDate(DateTime nordpoolPriceDateTime)
    {
        return _context.NordpoolPrices.Where(np => np.DateAndTime.Hour == nordpoolPriceDateTime.Hour).FirstOrDefault();
    }

    public ICollection<NordpoolPrice> GetNordpoolPrices()
    {
        return _context.NordpoolPrices.ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateNordpoolPrice(NordpoolPrice nordpoolPrice)
    {
        _context.Update(nordpoolPrice);
        return Save();
    }
}
