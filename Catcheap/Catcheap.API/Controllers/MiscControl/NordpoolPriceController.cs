using Catcheap.API.Interfaces.IRepository;
using Catcheap.API.Models.MiscModels;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.MiscControl;

[Route("api/[controller]")]
[ApiController]
public class NordpoolPriceController : Controller
{
    private readonly INordpoolPriceRepository _nordpoolPriceRepository;

    public NordpoolPriceController(INordpoolPriceRepository nordpoolPriceRepository)
    {
        _nordpoolPriceRepository = nordpoolPriceRepository;
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

        return Ok("Car successfully created");
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
            return BadRequest();

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
}
