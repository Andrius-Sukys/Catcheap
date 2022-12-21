using AutoMapper;
using Catcheap.API.DTO;
using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Models.ScooterModels;
using Catcheap.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.ScooterControl;

[Route("api/[controller]")]
[ApiController]
public class ScooterJourneyController : Controller
{
    private readonly IScooterJourneyRepository _journeyRepository;
    private readonly IScooterRepository _scooterRepository;
    private readonly IMapper _mapper;

    public ScooterJourneyController(IScooterJourneyRepository journeyRepository, IScooterRepository scooterRepository,
        IMapper mapper)
    {
        _journeyRepository = journeyRepository;
        _scooterRepository = scooterRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ScooterJourney>))]
    public IActionResult GetScooterJourneys()
    {
        var journeys = _mapper.Map<List<JourneyDTO>>(_journeyRepository.GetScooterJourneys());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(journeys);
    }

    [HttpGet("{journeyId}")]
    [ProducesResponseType(200, Type = typeof(ScooterJourney))]
    [ProducesResponseType(400)]
    public IActionResult GetScooterJourney(int journeyId)
    {
        if (!_journeyRepository.ScooterJourneyExists(journeyId))
            return NotFound();

        var journey = _mapper.Map<JourneyDTO>(_journeyRepository.GetScooterJourney(journeyId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(journey);
    }

    [HttpPost("{scooterId}/AddJourney")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateScooterJourney(int scooterId, JourneyDTO journeyCreate)
    {
        if (journeyCreate == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var journeyMap = _mapper.Map<ScooterJourney>(journeyCreate);

        journeyMap.Scooter = _scooterRepository.GetScooter(scooterId);

        if (!_journeyRepository.CreateScooterJourney(journeyMap))
        {
            ModelState.AddModelError("", "Unable to create the selected Scooter Journey.");
            return StatusCode(500, ModelState);
        }

        return Ok("Scooter Journey successfully created.");
    }

    [HttpPut("{journeyId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateScooterJourney(int journeyId, JourneyDTO updatedJourney)
    {
        if (updatedJourney == null)
            return BadRequest(ModelState);

        if (journeyId != updatedJourney.Id)
            return BadRequest(ModelState);

        if (!_journeyRepository.ScooterJourneyExists(journeyId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var journeyMap = _mapper.Map<ScooterJourney>(updatedJourney);

        if (!_journeyRepository.UpdateScooterJourney(journeyMap))
        {
            ModelState.AddModelError("", "Unable to update the selected Scooter Journey.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{journeyId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteScooterJourney(int journeyId)
    {
        if (!_journeyRepository.ScooterJourneyExists(journeyId))
        {
            return NotFound();
        }

        var journeyToDelete = _journeyRepository.GetScooterJourney(journeyId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_journeyRepository.DeleteScooterJourney(journeyToDelete))
        {
            ModelState.AddModelError("", "Unable to delete the selected Scooter Journey.");
        }

        return NoContent();
    }
}
