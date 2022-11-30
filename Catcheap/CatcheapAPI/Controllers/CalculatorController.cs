using CatcheapAPI.Models.Calculator_Classes;
using CatcheapAPI.Models.Vehicles_Classes.Cars_Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CatcheapAPI.Controllers
{
    [ApiController]
    [Route("api/Calculator")]
    public class CalculatorController : ControllerBase
    {
        [HttpPut]
        public ActionResult<double> CalculateFullChargePrice(Car car)
        {
            return Calculator.CalculateFullChargePrice(car.BatteryCapacity, car.BatteryLevel, 0.2);
        }
    }
}
