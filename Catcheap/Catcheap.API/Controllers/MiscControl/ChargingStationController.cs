using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Interfaces.IService.IMiscServices;
using Catcheap.API.Models.MiscModels;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.MiscControl;

[Route("api/[controller]")]
[ApiController]
public class ChargingStationController : Controller
{
    private readonly IChargingStationRepository _chargingStationRepository;

    private readonly IChargingStationsService _chargingStationService;

    public ChargingStationController(IChargingStationRepository chargingStationRepository,
        IChargingStationsService chargingStationService)
    {
        _chargingStationRepository = chargingStationRepository;
        _chargingStationService = chargingStationService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ChargingStation>))]
    public IActionResult GetChargingStations()
    {
        var chargingStations = _chargingStationRepository.GetChargingStations();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(chargingStations);
    }

    [HttpGet("{chargingStationId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ChargingStation>))]
    [ProducesResponseType(400)]
    public IActionResult GetChargingStation(int chargingStationId)
    {
        if (!_chargingStationRepository.ChargingStationExists(chargingStationId))
            return NotFound();

        var chargingStation = _chargingStationRepository.GetChargingStation(chargingStationId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(chargingStation);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateChargingStation(ChargingStation chargingStationCreate)
    {
        if (chargingStationCreate == null)
            return BadRequest(ModelState);

        var chargingStation = _chargingStationRepository.GetChargingStations()
            .Where(cs => cs.Street.Trim().ToUpper() == chargingStationCreate.Street.TrimEnd().ToUpper()
                   && cs.StreetNumber == chargingStationCreate.StreetNumber
                   && cs.City.Trim().ToUpper() == chargingStationCreate.City.TrimEnd().ToUpper())
            .FirstOrDefault();

        if (chargingStation != null)
        {
            ModelState.AddModelError("", "Charging Station already exists.");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_chargingStationRepository.CreateChargingStation(chargingStationCreate))
        {
            ModelState.AddModelError("", "Unable to create the selected Charging Station.");
            return StatusCode(500, ModelState);
        }

        return Ok("Charging Station successfully created.");
    }

    [HttpPut("{chargingStationId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateChargingStation(int chargingStationId, ChargingStation updatedChargingStation)
    {
        if (updatedChargingStation == null)
            return BadRequest(ModelState);

        if (chargingStationId != updatedChargingStation.Id)
            return BadRequest(ModelState);

        if (!_chargingStationRepository.ChargingStationExists(chargingStationId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_chargingStationRepository.UpdateChargingStation(updatedChargingStation))
        {
            ModelState.AddModelError("", "Unable to update the selected Charging Station.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{chargingStationId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteChargingStation(int chargingStationId)
    {
        if (!_chargingStationRepository.ChargingStationExists(chargingStationId))
        {
            return NotFound();
        }

        var chargingStationToDelete = _chargingStationRepository.GetChargingStation(chargingStationId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_chargingStationRepository.DeleteChargingStation(chargingStationToDelete))
        {
            ModelState.AddModelError("", "Unable to delete the selected Charging Station.");
        }

        return NoContent();
    }

    [HttpGet("Filter/{city}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ChargingStation>))]
    public IActionResult GetChargingStations(String city)
    {
        if(city == null)
        {
            return BadRequest(ModelState);
        }

        var chargingStations = _chargingStationService
            .FilterChargingStationsByCity(city);

        return Ok(chargingStations);
    }

}
