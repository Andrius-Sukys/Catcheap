using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Models.CarModels;


namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockCarChargeRepository : ICarChargeRepository
    {

        public bool CarChargeExists(int carChargeId)
        {
            return true;
        }

        public bool CreateCarCharge(CarCharge carCharge)
        {
            return true;
        }

        public bool DeleteCarCharge(CarCharge carCharge)
        {
            return true;
        }

        public bool DeleteCarCharges(List<CarCharge> carCharges)
        {
            return true;
        }

        public CarCharge GetCarCharge(int carChargeId)
        {
            CarCharge charge = new CarCharge();
            charge.Id = carChargeId;
            charge.Car = new Car();
            return charge;
        }

        public ICollection<CarCharge> GetCarCharges()
        {
            List <CarCharge> list = new List<CarCharge>();

            CarCharge charge = new CarCharge();
            charge.Car = new Car();

            list.Add(charge);

            return list;
        }

        public ICollection<CarCharge> GetChargesOfACar(int carId)
        {
            List<CarCharge> list = new List<CarCharge>();

            CarCharge charge = new CarCharge();
            charge.Car = new Car();
            charge.Car.Id = carId;

            list.Add(charge);

            return list;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateCarCharge(CarCharge carCharge)
        {
            return true;
        }

    }
}
