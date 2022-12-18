using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Models.ScooterModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcheap.Tests.CatcheapApi.MockRepo
{
    public class MockScooterChargeRepository : IScooterChargeRepository
    {
        public bool ScooterChargeExists(int scooterChargeId)
        {
            return true;
        }

        public bool CreateScooterCharge(ScooterCharge scooterCharge)
        {
            return true;
        }

        public bool DeleteScooterCharge(ScooterCharge scooterCharge)
        {
            return true;
        }

        public bool DeleteScooterCharges(List<ScooterCharge> scooterCharges)
        {
            return true;
        }

        public ScooterCharge GetScooterCharge(int scooterChargeId)
        {
            ScooterCharge scooterCharge = new ScooterCharge();
            scooterCharge.Id = scooterChargeId;
            scooterCharge.Scooter = new Scooter();
            return scooterCharge;
        }

        public ICollection<ScooterCharge> GetScooterCharges()
        {
            List<ScooterCharge> scooterCharges = new List<ScooterCharge>();

            ScooterCharge scooterCharge = new ScooterCharge();
            scooterCharge.Scooter = new Scooter();

            scooterCharges.Add(scooterCharge);

            return scooterCharges;
        }

        public ICollection<ScooterCharge> GetChargesOfAScooter(int scooterId)
        {
            List<ScooterCharge> scooterCharges = new List<ScooterCharge>();

            ScooterCharge scooterCharge = new ScooterCharge();
            scooterCharge.Scooter = new Scooter();
            scooterCharge.Scooter.Id = scooterId;

            scooterCharges.Add(scooterCharge);

            return scooterCharges;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateScooterCharge(ScooterCharge scooterCharge)
        {
            return true;
        }
    }
}
