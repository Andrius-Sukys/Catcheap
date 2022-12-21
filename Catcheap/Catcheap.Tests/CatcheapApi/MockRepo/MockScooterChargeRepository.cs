using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Models.CarModels;
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
        public ScooterCharge Charge { get; set; }

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
            Charge = new ScooterCharge();
            Charge.Id = scooterChargeId;
            return Charge;
        }

        public ICollection<ScooterCharge> GetScooterCharges()
        {
            List<ScooterCharge> list = new List<ScooterCharge>();
            Charge = new ScooterCharge();
            list.Add(Charge);

            return list;
        }

        public ICollection<ScooterCharge> GetChargesOfAScooter(int scooterId)
        {
            List<ScooterCharge> list = new List<ScooterCharge>();

            Charge = new ScooterCharge();

            Charge.Scooter = new Scooter();
            Charge.Scooter.Id = scooterId;
            Charge.Id = 10;
            Charge.StartOfCharge = new DateTime(2022, 12, 19, 12, 0, 0);
            Charge.ChargingPrice = 10;

            list.Add(Charge);

            return list;
        }

        public bool Save()
        {
            return true;
        }

        public bool UpdateScooterCharge(ScooterCharge scooterCharge)
        {
            Charge = scooterCharge;
            return true;
        }
    }
}
