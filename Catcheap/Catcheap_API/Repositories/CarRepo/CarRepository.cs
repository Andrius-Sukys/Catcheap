using Autofac.Extras.DynamicProxy;
using Catcheap_API.Data;
using Catcheap_API.Interfaces.IRepository;
using Catcheap_API.Logs;
using Catcheap_API.Models.CarModels;

namespace Catcheap_API.Repositories.CarRepo;

[Intercept(typeof(LogAspect))]
public class CarRepository : ICarRepository
{
    private readonly DataContext _context;

    public CarRepository(DataContext context)
    {
        _context = context;
    }

    public Car GetCar(int carId)
    {
        return _context.Cars.Where(c => c.Id == carId).FirstOrDefault();
    }

    public bool CarExists(int carId)
    {
        return _context.Cars.Any(c => c.Id == carId);
    }

    public ICollection<Car> GetCars()
    {
        return _context.Cars.OrderBy(c => c.Id).ToList();
    }

    public bool CreateCar(Car car)
    {
        _context.Add(car);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateCar(Car car)
    {
        _context.Update(car);
        return Save();
    }

    public bool DeleteCar(Car car)
    {
        _context.Remove(car);
        return Save();
    }
}
