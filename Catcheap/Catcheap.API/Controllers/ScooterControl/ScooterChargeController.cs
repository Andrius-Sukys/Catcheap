using AutoMapper;
using Catcheap.API.DTO;
using Catcheap.API.Interfaces.IRepository;
using Catcheap.API.Models.ScooterModels;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.ScooterControl;

[Route("api/[controller]")]
[ApiController]
public class ScooterChargeController : Controller
{
    private readonly IScooterChargeRepository _chargeRepository;
    private readonly IScooterRepository _scooterRepository;
    private readonly IMapper _mapper;

    public ScooterChargeController(IScooterChargeRepository chargeRepository,
        IScooterRepository scooterRepository, IMapper mapper)
    {
        _chargeRepository = chargeRepository;
        _scooterRepository = scooterRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<ScooterCharge>))]
    public IActionResult GetScooterCharges()
    {
        var charges = _mapper.Map<List<ChargeDTO>>(_chargeRepository.GetScooterCharges());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(charges);
    }

    [HttpGet("{chargeId}")]
    [ProducesResponseType(200, Type = typeof(ScooterCharge))]
    [ProducesResponseType(400)]
    public IActionResult GetScooterCharge(int chargeId)
    {
        if (!_chargeRepository.ScooterChargeExists(chargeId))
            return NotFound();

        var charge = _mapper.Map<ChargeDTO>(_chargeRepository.GetScooterCharge(chargeId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(charge);
    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateScooterCharge(int scooterId, ChargeDTO chargeCreate)
    {
        if (chargeCreate == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var chargeMap = _mapper.Map<ScooterCharge>(chargeCreate);

        chargeMap.Scooter = _scooterRepository.GetScooter(scooterId);

        if (!_chargeRepository.CreateScooterCharge(chargeMap))
        {
            ModelState.AddModelError("", "Unable to create the selected Scooter Charge.");
            return StatusCode(500, ModelState);
        }

        return Ok("Scooter Charge successfully created.");
    }

    [HttpPut("{chargeId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateScooterCharge(int chargeId, ChargeDTO updatedCharge)
    {
        if (updatedCharge == null)
            return BadRequest(ModelState);

        if (chargeId != updatedCharge.Id)
            return BadRequest(ModelState);

        if (!_chargeRepository.ScooterChargeExists(chargeId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest();

        var chargeMap = _mapper.Map<ScooterCharge>(updatedCharge);

        if (!_chargeRepository.UpdateScooterCharge(chargeMap))
        {
            ModelState.AddModelError("", "Unable to update the selected Scooter Charge.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{chargeId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteScooterCharge(int chargeId)
    {
        if (!_chargeRepository.ScooterChargeExists(chargeId))
        {
            return NotFound();
        }

        var chargeToDelete = _chargeRepository.GetScooterCharge(chargeId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_chargeRepository.DeleteScooterCharge(chargeToDelete))
        {
            ModelState.AddModelError("", "Unable to delete the selected Scooter Charge.");
        }

        return NoContent();
    }

}
