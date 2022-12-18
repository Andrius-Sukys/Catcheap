using Catcheap.API.Models.MiscModels;

namespace Catcheap.API.Interfaces.IService.IMiscServices;

public interface INordpoolPriceService
{
    NordpoolPrice GetNordpoolPriceCheapestSince(DateTime startDate);

    NordpoolPrice GetNordpoolPriceMostExpensiceSince(DateTime startDate);

    double GetNordpoolPricesAverageSince(DateTime startDate);
}
