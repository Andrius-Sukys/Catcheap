﻿using AutoMapper;
using Catcheap.API.DTO;
using Catcheap.API.Interfaces.IRepository.ICarRepo;
using Catcheap.API.Interfaces.IService.ICarServices;
using Catcheap.API.Models.CarModels;
using Microsoft.AspNetCore.Mvc;

namespace Catcheap.API.Controllers.CarControl;

[Route("api/[controller]")]
[ApiController]
public class CarChargeController : Controller
{
    private readonly ICarChargeRepository _chargeRepository;
    private readonly ICarRepository _carRepository;

    private readonly ICarChargeService _chargeService;

    private readonly IMapper _mapper;

    public CarChargeController(ICarChargeRepository chargeRepository,
        ICarRepository carRepository, ICarChargeService chargeService, IMapper mapper)
    {
        _chargeRepository = chargeRepository;
        _carRepository = carRepository;
        _chargeService= chargeService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<CarCharge>))]
    public IActionResult GetCarCharges()
    {
        var charges = _mapper.Map<List<ChargeDTO>>(_chargeRepository.GetCarCharges());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(charges);
    }

    [HttpGet("{chargeId}")]
    [ProducesResponseType(200, Type = typeof(CarCharge))]
    [ProducesResponseType(400)]
    public IActionResult GetCarCharge(int chargeId)
    {
        if (!_chargeRepository.CarChargeExists(chargeId))
            return NotFound();

        var charge = _mapper.Map<ChargeDTO>(_chargeRepository.GetCarCharge(chargeId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(charge);
    }

    [HttpPost("{carId}/AddCharge")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateCarCharge(int carId, ChargeDTO chargeCreate)
    {
        if (chargeCreate == null)
            return BadRequest(ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var chargeMap = _mapper.Map<CarCharge>(chargeCreate);

        chargeMap.Car = _carRepository.GetCar(carId);

        if (!_chargeRepository.CreateCarCharge(chargeMap))
        {
            ModelState.AddModelError("", "Unable to create the selected Car Charge.");
            return StatusCode(500, ModelState);
        }

        var chargeReturn = _mapper.Map<ChargeDTO>(_chargeRepository.GetCarCharge(chargeMap.Id));

        return Ok(chargeReturn);

    }

    [HttpPut("{chargeId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCarCharge(int chargeId, ChargeDTO updatedCharge)
    {
        if (updatedCharge == null)
            return BadRequest(ModelState);

        if (chargeId != updatedCharge.Id)
            return BadRequest(ModelState);

        if (!_chargeRepository.CarChargeExists(chargeId))
            return NotFound();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var chargeMap = _mapper.Map<CarCharge>(updatedCharge);

        if (!_chargeRepository.UpdateCarCharge(chargeMap))
        {
            ModelState.AddModelError("", "Unable to update the selected Car Charge.");
            return StatusCode(500, ModelState);
        }

        return NoContent();
    }

    [HttpDelete("{chargeId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCarCharge(int chargeId)
    {
        if (!_chargeRepository.CarChargeExists(chargeId))
        {
            return NotFound();
        }

        var chargeToDelete = _chargeRepository.GetCarCharge(chargeId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (!_chargeRepository.DeleteCarCharge(chargeToDelete))
        {
            ModelState.AddModelError("", "Unable to delete the selected Car Charge.");
        }

        return NoContent();
    }

    [HttpGet("{chargeId}/CalculatePrice")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult CalculateChargePriceForCar(int chargeId)
    {
        if (!_chargeRepository.CarChargeExists(chargeId))
        {
            return NotFound();
        }
            
        var chargeToCalculate = _chargeRepository.GetCarCharge(chargeId);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        _chargeService.CalculateChargePrice(chargeToCalculate);

        return NoContent();
    }

}
