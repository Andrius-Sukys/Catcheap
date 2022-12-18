using Catcheap.API.Models.ScooterModels;

namespace Catcheap.API.Interfaces.IRepository.IScooterRepo;

public interface IScooterChargeRepository
{
    ICollection<ScooterCharge> GetScooterCharges();

    ICollection<ScooterCharge> GetChargesOfAScooter(int scooterId);

    ScooterCharge GetScooterCharge(int scooterChargeId);

    bool ScooterChargeExists(int scooterChargeId);

    bool CreateScooterCharge(ScooterCharge scooterCharge);

    bool UpdateScooterCharge(ScooterCharge scooterCharge);

    bool DeleteScooterCharge(ScooterCharge scooterCharge);

    bool DeleteScooterCharges(List<ScooterCharge> scooterCharges);

    bool Save();
}
