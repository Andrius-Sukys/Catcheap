using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Interfaces.IService.IMiscServices;
using Catcheap.API.Models.MiscModels;

namespace Catcheap.API.Services.MiscServices;

public class ChargingStationsService : IChargingStationsService
{
    private readonly IChargingStationRepository _chargingStationRepository;

    public ChargingStationsService(IChargingStationRepository chargingStationRepository)
    {
        _chargingStationRepository = chargingStationRepository;
    }

    public IEnumerable<ChargingStation> FilterChargingStationsByCity(string city)
    {
        var chargingStations = _chargingStationRepository
                                .GetChargingStations()
                                .Where(gcs => gcs.City == city);

        return chargingStations;
    }
}
