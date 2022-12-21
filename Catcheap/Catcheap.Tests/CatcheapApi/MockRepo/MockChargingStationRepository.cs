using Catcheap.API.Data;
using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Models.MiscModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockChargingStationRepository : IChargingStationRepository
    {

        public bool ChargingStationExists(int chargingStationId)
        {
            return true;
        }

        public bool CreateChargingStation(ChargingStation chargingStation)
        {
            return true;
        }

        public bool DeleteChargingStation(ChargingStation chargingStation)
        {
            return true;
        }

        public ChargingStation GetChargingStation(int chargingStationId)
        {
            ChargingStation chargingStation = new ChargingStation();
            chargingStation.Id = chargingStationId;
            return chargingStation;
        }

        public ICollection<ChargingStation> GetChargingStations()
        {
            List<ChargingStation> chargingStations = new List<ChargingStation>();
            ChargingStation station = new ChargingStation();
            station.Id = 69;
            station.City = "Vilnius";
            station.Street = "labas";
            station.StreetNumber = 1;
            chargingStations.Add(station);
            return chargingStations;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateChargingStation(ChargingStation chargingStation)
        {
            return true;
        }
    }
}
