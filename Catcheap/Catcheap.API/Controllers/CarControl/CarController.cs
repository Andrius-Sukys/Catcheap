using AutoMapper;
using Catcheap.API.Interfaces.IService;
using Catcheap.API.DTO;
using Catcheap.API.Helper;
using Catcheap.API.Interfaces.IRepository;
using Catcheap.API.Models.CarModels;
using Catcheap.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.CarControl;

[Route("api/[controller]")]
[ApiController]
public class CarController : Controller
{
    private readonly ICarRepository _carRepository;
    private readonly ICarJourneyRepository _journeyRepository;
    private readonly ICarChargeRepository _chargeRepository;

    private readonly ICarService _carService;

    private readonly IMapper _mapper;

    public CarController(ICarRepository carRepository, ICarJourneyRepository journeyRepository,
        ICarChargeRepository chargeRepository, IMapper mapper, ICarService carService)
    {
        _carRepository = carRepository;
        _journeyRepository = journeyRepository;
        _chargeRepository = chargeRepository;
        _mapper = mapper;
        _carService = carService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
    public IActionResult GetCars()
    {
        var cars = _mapper.Map<List<CarDTO>>(_carRepository.GetCars());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(cars);
    }

    [HttpGet("{carId}")]
    [ProducesResponseType(200, Type = typeof(Car))]
    [ProducesResponseType(400)]
    public IActionResult GetCar(int carId)
    {
        if (!_carRepository.CarExists(carId))
            return NotFound();

        var car = _mapper.Map<CarDTO>(_carRepository.GetCar(carId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(car);
    }

    [HttpGet("{carId}/GetCharges")]
    [ProducesResponseType(200, Type = typeof(CarCharge))]
    [ProducesResponseType(400)]
    public IActionResult GetChargesOfACar(int carId)
    {
        if (!_carRepository.CarExists(carId))
            return NotFound();

        var charges = _mapper.Map<ChargeDTO>(_chargeRepository.GetChargesOfACar(carId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(charges);
    }

    [HttpGet("{carId}/GetJourneys")]
    [ProducesResponseType(200, Type = typeof(CarJourney))]
    [ProducesResponseType(400)]
    public IActionResult GetJourneysOfACar(int carId)
    {
        if (!_carRepository.CarExists(carId))
            return NotFound();

        var journeys = _mapper.Map<JourneyDTO>(_journeyRepository.GetJourneysOfACar(carId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(journeys);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateCar(CarDTO carCreate)
    {
        if (carCreate == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var carMap = _mapper.Map<Car>(carCreate);

        if (!_carRepository.CreateCar(carMap))
        {
            ModelState.AddModelError("", "Unable to create the selected Car.");
            return StatusCode(500, ModelState);
        }

        return Ok("Car successfully created.");
    }

    [HttpPut("{carId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCar(int carId, CarDTO updatedCar)
    {
        if (updatedCar == null)
            return BadRequest(ModelState);

        if (carId != updatedCar.Id)
            return BadRequest(ModelState);

        if (!_carRepository.CarExists(carId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var carMap = _mapper.Map<Car>(updatedCar);

        if (!_carRepository.UpdateCar(carMap))
        {
            ModelState.AddModelError("", "Unable to update the selected Car.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{carId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCar(int carId)
    {
        if (!_carRepository.CarExists(carId))
        {
            return NotFound();
        }

        var carToDelete = _carRepository.GetCar(carId);

        var journeysToDelete = _journeyRepository.GetJourneysOfACar(carId).ToList();

        if (!ModelState.IsValid)
            return BadRequest();

        var chargesToDelete = _chargeRepository.GetChargesOfACar(carId).ToList();

        if (!ModelState.IsValid)
            return BadRequest();

        if (journeysToDelete.Any())
        {
            if (!_journeyRepository.DeleteCarJourneys(journeysToDelete))
            {
                ModelState.AddModelError("", "Unable to delete the selected Car: error deleting Journeys.");
                return StatusCode(500, ModelState);
            }
        }

        if (chargesToDelete.Any())
        {
            if (!_chargeRepository.DeleteCarCharges(chargesToDelete))
            {
                ModelState.AddModelError("", "Unable to delete the selected Car: error deleting Charges.");
                return StatusCode(500, ModelState);
            }
        }

        _carRepository.DeleteCar(carToDelete);

        return NoContent();
    }

    [HttpPut("{carId}/UpdateAfterJourney/{journeyId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCarAfterJourney(int carId, int journeyId)
    {
        if (!_carRepository.CarExists(carId))
        {
            return NotFound();
        }

        var carToUpdate = _carRepository.GetCar(carId);

        if (!ModelState.IsValid)
            return BadRequest();

        if(!_journeyRepository.CarJourneyExists(journeyId))
        {
            return NotFound();
        }

        var journeyToUpdate = _journeyRepository.GetCarJourney(journeyId);


        _carService.UpdateAfterJourney(carToUpdate, journeyToUpdate);

        return NoContent();
    }

    [HttpGet("{carId}/CalculateExpectedRange")]
    [ProducesResponseType(200, Type = typeof(Car))]
    [ProducesResponseType(400)]
    public IActionResult CalculateExpectedRangeForCar(int carId)
    {
        if(!_carRepository.CarExists(carId))
        {
            return NotFound();
        }

        var carToCalculate = _carRepository.GetCar(carId);

        if (!ModelState.IsValid)
            return BadRequest();

        _carService.CalculateExpectedRange(carToCalculate);

        return Ok(carToCalculate);

    }
}
