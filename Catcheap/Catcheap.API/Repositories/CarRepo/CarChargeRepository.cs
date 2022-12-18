using Catcheap.API.Data;
using Catcheap.API.Helper;
using Catcheap.API.Models.CarModels;
using Catcheap.API.Interfaces.IRepository.ICarRepo;

namespace Catcheap.API.Repositories.CarRepo;

public class CarChargeRepository : ICarChargeRepository
{
    private readonly DataContext _context;

    public CarChargeRepository(DataContext context)
    {
        _context = context;
    }

    public bool CarChargeExists(int carChargeId)
    {
        return _context.CarCharges.Any(cc => cc.Id == carChargeId);
    }

    public bool CreateCarCharge(CarCharge carCharge)
    {
        _context.Add(carCharge);
        return Save();
    }

    public bool DeleteCarCharge(CarCharge carCharge)
    {
        _context.Remove(carCharge);
        return Save();
    }

    public bool DeleteCarCharges(List<CarCharge> carCharges)
    {
        _context.RemoveRange(carCharges);
        return Save();
    }

    public CarCharge GetCarCharge(int carChargeId)
    {
        return _context.CarCharges.Where(cc => cc.Id == carChargeId).FirstOrDefault();
    }

    public ICollection<CarCharge> GetCarCharges()
    {
        return _context.CarCharges.OrderByDescending(cc => cc.EndOfCharge).ToList();
    }

    public ICollection<CarCharge> GetChargesOfACar(int carId)
    {
        return _context.CarCharges.Where(cc => cc.Car.Id == carId).ToList();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateCarCharge(CarCharge carCharge)
    {
        _context.Update(carCharge);
        return Save();
    }
}
