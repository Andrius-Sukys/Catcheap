using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Interfaces.IService.IMiscServices;
using Catcheap.API.Models.MiscModels;

namespace Catcheap.API.Services.MiscServices;

public class NordpoolPriceService : INordpoolPriceService
{
    private readonly INordpoolPriceRepository _nordpoolPriceRepository;

    public NordpoolPriceService(INordpoolPriceRepository nordpoolPriceRepository)
    {
        _nordpoolPriceRepository = nordpoolPriceRepository;
    }

    public NordpoolPrice GetNordpoolPriceCheapestSince(DateTime startDate)
    {
        return _nordpoolPriceRepository.GetNordpoolPrices().Where(np => np.DateAndTime > startDate).Min();
    }

    public NordpoolPrice GetNordpoolPriceMostExpensiceSince(DateTime startDate)
    {
        return _nordpoolPriceRepository.GetNordpoolPrices().Where(np => np.DateAndTime > startDate).Max();
    }

    public double GetNordpoolPricesAverageSince(DateTime startDate)
    {
        return _nordpoolPriceRepository.GetNordpoolPrices().Where(np => np.DateAndTime > startDate).Select(np => np.Price).Average();
    }
}
