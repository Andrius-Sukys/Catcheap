using Catcheap.API.Interfaces.IRepository.IMiscRepo;
using Catcheap.API.Interfaces.IService.IMiscServices;
using Catcheap.API.Models.MiscModels;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.MiscControl;

[Route("api/[controller]")]
[ApiController]
public class NordpoolPriceController : Controller
{
    private readonly INordpoolPriceRepository _nordpoolPriceRepository;

    private readonly INordpoolPriceService _nordpoolPriceService;

    public NordpoolPriceController(INordpoolPriceRepository nordpoolPriceRepository,
        INordpoolPriceService nordpoolPriceService)
    {
        _nordpoolPriceRepository = nordpoolPriceRepository;
        _nordpoolPriceService = nordpoolPriceService;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<NordpoolPrice>))]
    public IActionResult GetNordpoolPrices()
    {
        var nordpoolPrices = _nordpoolPriceRepository.GetNordpoolPrices();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(nordpoolPrices);
    }

    [HttpGet("{nordpoolPriceId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<NordpoolPrice>))]
    [ProducesResponseType(400)]
    public IActionResult GetNordpoolPrice(int nordpoolPriceId)
    {
        if (!_nordpoolPriceRepository.NordpoolPriceExists(nordpoolPriceId))
            return NotFound();

        var nordpoolPrice = _nordpoolPriceRepository.GetNordpoolPrice(nordpoolPriceId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(nordpoolPrice);
    }

    [HttpGet("ByDate/{nordpoolPriceDate}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<NordpoolPrice>))]
    [ProducesResponseType(400)]
    public IActionResult GetNordpoolPriceByDate(DateTime nordpoolPriceDate)
    {
        if (!_nordpoolPriceRepository.NordpoolPriceExistsByDate(nordpoolPriceDate))
            return NotFound();

        var nordpoolPrice = _nordpoolPriceRepository.GetNordpoolPriceByDate(nordpoolPriceDate);

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(nordpoolPrice);

    }

    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateNordpoolPrice(NordpoolPrice nordpoolPriceCreate)
    {
        if (nordpoolPriceCreate == null)
            return BadRequest(ModelState);

        var nordpoolPrice = _nordpoolPriceRepository.GetNordpoolPrices()
            .Where(np => np.DateAndTime == nordpoolPriceCreate.DateAndTime)
            .FirstOrDefault();

        if (nordpoolPrice != null)
        {
            ModelState.AddModelError("", "Nordpool Price already exists.");
            return StatusCode(422, ModelState);
        }

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_nordpoolPriceRepository.CreateNordpoolPrice(nordpoolPriceCreate))
        {
            ModelState.AddModelError("", "Unable to create the selected Nordpool Price.");
            return StatusCode(500, ModelState);
        }

        return Ok("Nordpool Price successfully created.");
    }

    [HttpPut("{nordpoolPriceId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateNordpoolPrice(int nordpoolPriceId, NordpoolPrice updatedNordpoolPrice)
    {
        if (updatedNordpoolPrice == null)
            return BadRequest(ModelState);

        if (nordpoolPriceId != updatedNordpoolPrice.Id)
            return BadRequest(ModelState);

        if (!_nordpoolPriceRepository.NordpoolPriceExists(nordpoolPriceId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_nordpoolPriceRepository.UpdateNordpoolPrice(updatedNordpoolPrice))
        {
            ModelState.AddModelError("", "Unable to update the selected Nordpool Price.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{nordpoolPriceId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteNordpoolPrice(int nordpoolPriceId)
    {
        if (!_nordpoolPriceRepository.NordpoolPriceExists(nordpoolPriceId))
        {
            return NotFound();
        }

        var nordpoolPriceToDelete = _nordpoolPriceRepository.GetNordpoolPrice(nordpoolPriceId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_nordpoolPriceRepository.DeleteNordpoolPrice(nordpoolPriceToDelete))
        {
            ModelState.AddModelError("", "Unable to delete the selected Nordpool Price.");
        }

        return NoContent();
    }

    [HttpGet("CheapestSince/{dateSince}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<NordpoolPrice>))]
    public IActionResult GetNordpoolPriceCheapest(DateTime dateSince)
    {
        if(!_nordpoolPriceRepository.NordpoolPriceExistsAny())
        {
            return NotFound();
        }

        var nordpoolPriceCheapest = _nordpoolPriceService.GetNordpoolPriceCheapestSince(dateSince);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(nordpoolPriceCheapest);
    }

    [HttpGet("MostExpensiveSince/{dateSince}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<NordpoolPrice>))]
    public IActionResult GetNordpoolPriceMostExpensive(DateTime dateSince)
    {
        if (!_nordpoolPriceRepository.NordpoolPriceExistsAny())
        {
            return NotFound();
        }

        var nordpoolPriceMostExpensive = _nordpoolPriceService.GetNordpoolPriceMostExpensiceSince(dateSince);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(nordpoolPriceMostExpensive);
    }

    [HttpGet("AverageSince/{dateSince}")]
    [ProducesResponseType(200, Type = typeof(double))]
    public IActionResult GetNordpoolPriceAverage(DateTime dateSince)
    {
        if (!_nordpoolPriceRepository.NordpoolPriceExistsAny())
        {
            return NotFound();
        }

        var nordpoolPriceAverage = _nordpoolPriceService.GetNordpoolPricesAverageSince(dateSince);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(nordpoolPriceAverage);
    }
}
