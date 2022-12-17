using CatcheapAPI.Data;

namespace CatcheapAPI.Repositories
{
    public class CarsRepository //: IRepository<Car, int>
    {
        private readonly CatcheapAPIContext _context;
        public CarsRepository(CatcheapAPIContext context) => _context = context;


    }
}
