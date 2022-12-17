﻿using Catcheap.API.Models.MiscModels;

namespace Catcheap.API.Interfaces.IRepository;

public interface INordpoolPriceRepository
{
    ICollection<NordpoolPrice> GetNordpoolPrices();

    NordpoolPrice GetNordpoolPrice(int nordpoolPriceId);

    bool NordpoolPriceExists(int nordpoolPriceId);

    bool CreateNordpoolPrice(NordpoolPrice nordpoolPrice);

    bool UpdateNordpoolPrice(NordpoolPrice nordpoolPrice);

    bool DeleteNordpoolPrice(NordpoolPrice nordpoolPrice);

    public bool NordpoolPriceExistsByDate(DateTime nordpoolPriceDateTime);

    public NordpoolPrice GetNordpoolPriceByDate(DateTime nordpoolPriceDateTime);

    bool Save();
}
