using Catcheap_API.Models.CarModels;

namespace Catcheap_API.Interfaces.IRepository;

public interface ICarChargeRepository
{
    ICollection<CarCharge> GetCarCharges();

    ICollection<CarCharge> GetChargesOfACar(int carId);

    CarCharge GetCarCharge(int carChargeId);

    bool CarChargeExists(int carChargeId);

    bool CreateCarCharge(CarCharge carCharge);

    bool UpdateCarCharge(CarCharge carCharge);

    bool DeleteCarCharge(CarCharge carCharge);

    bool DeleteCarCharges(List<CarCharge> carCharges);

    bool Save();
}
