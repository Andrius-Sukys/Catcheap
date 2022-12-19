using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Models.CarModels;


namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockCarChargeRepository : ICarChargeRepository
    {
        public CarCharge Charge { get; set; }

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
            Charge = new CarCharge();
            Charge.Id = carChargeId;
            return Charge;
        }

        public ICollection<CarCharge> GetCarCharges()
        {
            List <CarCharge> list = new List<CarCharge>();
            Charge = new CarCharge();
            list.Add(Charge);

            return list;
        }

        public ICollection<CarCharge> GetChargesOfACar(int carId)
        {
            List<CarCharge> list = new List<CarCharge>();

            Charge = new CarCharge();

            Charge.Car = new Car();
            Charge.Car.Id = carId;
            Charge.StartOfCharge = new DateTime(2022, 12, 19, 12, 0, 0);
            Charge.ChargingPrice = 10;

            list.Add(Charge);

            return list;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateCarCharge(CarCharge carCharge)
        {
            Charge = carCharge;
            return true;
        }

    }
}
