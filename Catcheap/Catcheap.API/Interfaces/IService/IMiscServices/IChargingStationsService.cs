using Catcheap.API.Models.MiscModels;

namespace Catcheap.API.Interfaces.IService.IMiscServices;

public interface IChargingStationsService
{
    IEnumerable<ChargingStation> FilterChargingStationsByCity(string city);
}
