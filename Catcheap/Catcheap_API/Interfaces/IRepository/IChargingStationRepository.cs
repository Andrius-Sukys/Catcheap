using Catcheap_API.Models.MiscModels;

namespace Catcheap_API.Interfaces.IRepository;

public interface IChargingStationRepository
{
    ICollection<ChargingStation> GetChargingStations();

    ChargingStation GetChargingStation(int chargingStationId);

    bool ChargingStationExists(int chargingStationId);

    bool CreateChargingStation(ChargingStation chargingStation);

    bool UpdateChargingStation(ChargingStation chargingStation);

    bool DeleteChargingStation(ChargingStation chargingStation);

    bool Save();
}
