using Catcheap.API.Interfaces.IRepository.IScooterRepo;
using Catcheap.API.Interfaces.IService.IScooterServices;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.CarControl;

[Route("api/[controller]")]
[ApiController]
public class ScooterStatsController : Controller
{
    private readonly IScooterRepository _scooterRepository;

    private readonly IScooterStatsService _statsService;

    public ScooterStatsController(IScooterRepository scooterRepository, IScooterStatsService statsService)
    {
        _scooterRepository = scooterRepository;
        _statsService = statsService;
    }

    [HttpGet("{scooterId}/ChargesSince/{startDate}")]
    [ProducesResponseType(200, Type = typeof(double))]
    [ProducesResponseType(400)]
    public IActionResult GetScooterChargesCount(int scooterId, DateTime startDate)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        var count = _statsService.GetChargesCountSince(scooterId, startDate);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(count);
    }

    [HttpGet("{scooterId}/JourneysSince/{startDate}")]
    [ProducesResponseType(200, Type = typeof(double))]
    [ProducesResponseType(400)]
    public IActionResult GetScooterJourneysCount(int scooterId, DateTime startDate)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        var count = _statsService.GetJourneysCountSince(scooterId, startDate);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(count);
    }

    [HttpGet("{scooterId}/JourneyDistanceSince/{startDate}")]
    [ProducesResponseType(200, Type = typeof(double))]
    [ProducesResponseType(400)]
    public IActionResult GetScooterJourneyDistance(int scooterId, DateTime startDate)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        var distance = _statsService.GetJourneyDistanceSince(scooterId, startDate);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(distance);
    }

    [HttpGet("{scooterId}/ConsumptionSince/{startDate}")]
    [ProducesResponseType(200, Type = typeof(double))]
    [ProducesResponseType(400)]
    public IActionResult GetScooterConsumption(int scooterId, DateTime startDate)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        var consumption = _statsService.GetConsumptionSince(scooterId, startDate);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(consumption);
    }

    [HttpGet("{scooterId}/MoneySpentSince/{startDate}")]
    [ProducesResponseType(200, Type = typeof(double))]
    [ProducesResponseType(400)]
    public IActionResult GetCarMoneySpent(int scooterId, DateTime startDate)
    {
        if (!_scooterRepository.ScooterExists(scooterId))
            return NotFound();

        var moneySpent = _statsService.GetMoneySpentSince(scooterId, startDate);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(moneySpent);
    }
}
