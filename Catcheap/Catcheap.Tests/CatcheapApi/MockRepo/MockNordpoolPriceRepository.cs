using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Models.MiscModels;

namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockNordpoolPriceRepository : INordpoolPriceRepository
    {

        public bool NordpoolPriceExistsAny()
        {
            return true;
        }

        public bool NordpoolPriceExists(int nordpoolPriceId)
        {
            return true;
        }

        public bool NordpoolPriceExistsByDate(DateTime nordpoolPriceDateTime)
        {
            return true;
        }

        public bool CreateNordpoolPrice(NordpoolPrice nordpoolPrice)
        {
            return true;
        }

        public bool DeleteNordpoolPrice(NordpoolPrice nordpoolPrice)
        {
            return true;
        }

        public NordpoolPrice GetNordpoolPrice(int nordpoolPriceId)
        {
            NordpoolPrice nordpoolPrice = new NordpoolPrice();
            nordpoolPrice.Id = nordpoolPriceId;
            return nordpoolPrice;
        }

        public NordpoolPrice GetNordpoolPriceByDate(DateTime nordpoolPriceDateTime)
        {
            NordpoolPrice nordpoolPrice = new NordpoolPrice();
            nordpoolPrice.DateAndTime = nordpoolPriceDateTime;
            nordpoolPrice.Price = 1;
            return nordpoolPrice;
        }

        public ICollection<NordpoolPrice> GetNordpoolPrices()
        {
            List<NordpoolPrice> nordpoolPrices = new List<NordpoolPrice>();
            nordpoolPrices.Add(new NordpoolPrice());
            return nordpoolPrices;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateNordpoolPrice(NordpoolPrice nordpoolPrice)
        {
            return true;
        }
    }
}
