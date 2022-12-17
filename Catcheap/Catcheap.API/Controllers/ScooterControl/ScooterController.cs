using AutoMapper;
using Catcheap.API.DTO;
using Catcheap.API.Interfaces.IRepository;
using Catcheap.API.Models.ScooterModels;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.ScooterControl;

[Route("api/[controller]")]
[ApiController]
public class ScooterController : Controller
{
    private readonly IScooterRepository _scooterRepository;
    private readonly IScooterJourneyRepository _journeyRepository;
    private readonly IScooterChargeRepository _chargeRepository;
    private readonly IMapper _mapper;

    public ScooterController(IScooterRepository scooterRepository, IScooterJourneyRepository journeyRepository,
        IScooterChargeRepository chargeRepository, IMapper mapper)
    {
        _scooterRepository = scooterRepository;
        _journeyRepository = journeyRepository;
        _chargeRepository = chargeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Scooter>))]
    public IActionResult GetScooters()
    {
        var scooters = _mapper.Map<List<ScooterDTO>>(_scooterRepository.GetScooters());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(scooters);
    }

    [HttpGet("{scooterId}")]
    [ProducesResponseType(200, Type = typeof(Scooter))]
    [ProducesResponseType(400)]
    public IActionResult GetScooter(int scooterId)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        var scooter = _mapper.Map<ScooterDTO>(_scooterRepository.GetScooter(scooterId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(scooter);
    }

    [HttpGet("{scooterId}/charge")]
    [ProducesResponseType(200, Type = typeof(ScooterCharge))]
    [ProducesResponseType(400)]
    public IActionResult GetChargesOfAScooter(int scooterId)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        var charges = _mapper.Map<ChargeDTO>(_chargeRepository.GetChargesOfAScooter(scooterId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(charges);
    }

    [HttpGet("{scooterId}/journey")]
    [ProducesResponseType(200, Type = typeof(ScooterCharge))]
    [ProducesResponseType(400)]
    public IActionResult GetJourneysOfAScooter(int scooterId)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        var journeys = _mapper.Map<JourneyDTO>(_journeyRepository.GetJourneysOfAScooter(scooterId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(journeys);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateScooter(ScooterDTO scooterCreate)
    {
        if (scooterCreate == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var scooterMap = _mapper.Map<Scooter>(scooterCreate);

        if (!_scooterRepository.CreateScooter(scooterMap))
        {
            ModelState.AddModelError("", "Unable to create the selected Scooter.");
            return StatusCode(500, ModelState);
        }

        return Ok("Scooter successfully created.");
    }

    [HttpPut("{scooterId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateScooter(int scooterId, ScooterDTO updatedScooter)
    {
        if (updatedScooter == null)
            return BadRequest(ModelState);

        if (scooterId != updatedScooter.Id)
            return BadRequest(ModelState);

        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var scooterMap = _mapper.Map<Scooter>(updatedScooter);

        if (!_scooterRepository.UpdateScooter(scooterMap))
        {
            ModelState.AddModelError("", "Unable to update the selected Scooter.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{scooterId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteScooter(int scooterId)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
        {
            return NotFound();
        }

        var scooterToDelete = _scooterRepository.GetScooter(scooterId);

        var journeysToDelete = _journeyRepository.GetJourneysOfAScooter(scooterId).ToList();

        if (!ModelState.IsValid)
            return BadRequest();

        var chargesToDelete = _chargeRepository.GetChargesOfAScooter(scooterId).ToList();

        if (!ModelState.IsValid)
            return BadRequest();

        if (journeysToDelete.Any())
        {
            if (!_journeyRepository.DeleteScooterJourneys(journeysToDelete))
            {
                ModelState.AddModelError("", "Unable to delete the selected Scooter: error deleting Journeys.");
                return StatusCode(500, ModelState);
            }
        }

        if (chargesToDelete.Any())
        {
            if (!_chargeRepository.DeleteScooterCharges(chargesToDelete))
            {
                ModelState.AddModelError("", "Unable to delete the selected Car: error deleting Charges.");
                return StatusCode(500, ModelState);
            }
        }

        _scooterRepository.DeleteScooter(scooterToDelete);

        return NoContent();
    }
}
