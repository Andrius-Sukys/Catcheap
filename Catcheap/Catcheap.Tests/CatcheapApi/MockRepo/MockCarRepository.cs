using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Models.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockCarRepository : ICarRepository
    {

        public Car GetCar(int carId)
        {
            Car car = new Car();
            car.Id = carId;
            return car;
        }

        public bool CarExists(int carId)
        {
            return true;
        }

        public ICollection<Car> GetCars()
        {
            List<Car> list = new List<Car>();
            list.Add(new Car());
            return list;
        }

        public bool CreateCar(Car car)
        {
            return true;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateCar(Car car)
        {
            return true;
        }

        public bool DeleteCar(Car car)
        {
            return true;
        }
    }
}
