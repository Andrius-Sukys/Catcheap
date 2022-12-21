using AutoMapper;
using Catcheap.API.DTO;
using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Models.CarModels;
using Catcheap.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.CarControl;

[Route("api/[controller]")]
[ApiController]
public class CarJourneyController : Controller
{
    private readonly ICarJourneyRepository _journeyRepository;
    private readonly ICarRepository _carRepository;
    private readonly IMapper _mapper;

    public CarJourneyController(ICarJourneyRepository journeyRepository, ICarRepository carRepository, IMapper mapper)
    {
        _journeyRepository = journeyRepository;
        _carRepository = carRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CarJourney>))]
    public IActionResult GetCarJourneys()
    {
        var journeys = _mapper.Map<List<JourneyDTO>>(_journeyRepository.GetCarJourneys());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(journeys);
    }

    [HttpGet("{journeyId}")]
    [ProducesResponseType(200, Type = typeof(CarJourney))]
    [ProducesResponseType(400)]
    public IActionResult GetCarJourney(int journeyId)
    {
        if (!_journeyRepository.CarJourneyExists(journeyId))
            return NotFound();

        var journey = _mapper.Map<JourneyDTO>(_journeyRepository.GetCarJourney(journeyId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(journey);
    }

    [HttpPost("{carId}/AddJourney")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateCarJourney(int carId, JourneyDTO journeyCreate)
    {
        if (journeyCreate == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var journeyMap = _mapper.Map<CarJourney>(journeyCreate);

        journeyMap.Car = _carRepository.GetCar(carId);

        if (!_journeyRepository.CreateCarJourney(journeyMap))
        {
            ModelState.AddModelError("", "Unable to create the selected Car Journey.");
            return StatusCode(500, ModelState);
        }

        var journeyReturn = _mapper.Map <JourneyDTO>(_journeyRepository.GetCarJourney(journeyMap.Id));

        return Ok(journeyReturn);
    }

    [HttpPut("{journeyId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCarJourney(int journeyId, JourneyDTO updatedJourney)
    {
        if (updatedJourney == null)
            return BadRequest(ModelState);

        if (journeyId != updatedJourney.Id)
            return BadRequest(ModelState);

        if (!_journeyRepository.CarJourneyExists(journeyId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var journeyMap = _mapper.Map<CarJourney>(updatedJourney);

        if (!_journeyRepository.UpdateCarJourney(journeyMap))
        {
            ModelState.AddModelError("", "Unable to update the selected Car Journey.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{journeyId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCarJourney(int journeyId)
    {
        if (!_journeyRepository.CarJourneyExists(journeyId))
        {
            return NotFound();
        }

        var journeyToDelete = _journeyRepository.GetCarJourney(journeyId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_journeyRepository.DeleteCarJourney(journeyToDelete))
        {
            ModelState.AddModelError("", "Unable to delete the selected Car Journey.");
        }

        return NoContent();
    }
}
