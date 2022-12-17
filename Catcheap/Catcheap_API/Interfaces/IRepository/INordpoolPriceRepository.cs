using Catcheap_API.Models.MiscModels;

namespace Catcheap_API.Interfaces.IRepository;

public interface INordpoolPriceRepository
{
    ICollection<NordpoolPrice> GetNordpoolPrices();

    NordpoolPrice GetNordpoolPrice(int nordpoolPriceId);

    bool NordpoolPriceExists(int nordpoolPriceId);

    bool CreateNordpoolPrice(NordpoolPrice nordpoolPrice);

    bool UpdateNordpoolPrice(NordpoolPrice nordpoolPrice);

    bool DeleteNordpoolPrice(NordpoolPrice nordpoolPrice);

    bool Save();
}
