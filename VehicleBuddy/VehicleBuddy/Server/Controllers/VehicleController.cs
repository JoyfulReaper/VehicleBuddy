using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Server.Repositories.Interfaces;
using VehicleBuddy.Shared.Contracts.Vehicle;

namespace VehicleBuddy.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleController(
        IMapper mapper,
        IVehicleRepository vehicleRepository)
    {
        _mapper = mapper;
        _vehicleRepository = vehicleRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleResponse>>> GetVehicles()
    {
        var vehicles = await _vehicleRepository.GetAllAsync();
        var vehicleResponses = _mapper.Map<IEnumerable<VehicleResponse>>(vehicles);

        return Ok(vehicleResponses);
    }

    [HttpGet("Vin/{vin}")]
    public async Task<ActionResult<VehicleResponse>> GetVehicleByVin(string vin)
    {
        var vehicle = await _vehicleRepository.GetByVinAsync(vin, false);

        return vehicle == null ? NotFound() : Ok(_mapper.Map<VehicleResponse>(vehicle));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<VehicleResponse>> GetVehicleById(int id)
    {
        var vehicle = await _vehicleRepository.GetAsync(id);

        return vehicle == null ? NotFound() : Ok(_mapper.Map<VehicleResponse>(vehicle));
    }


    [HttpPost]
    public async Task<ActionResult<VehicleResponse>> CreateVehicle(CreateVehicleRequest createVehicle)
    {
        var vehicle = _mapper.Map<Vehicle>(createVehicle);
        await _vehicleRepository.SaveAsync(vehicle);
        var savedVehicle = await _vehicleRepository.GetAsync(vehicle.VehicleId);

        if (savedVehicle == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return CreatedAtAction(nameof(GetVehicleById), _mapper.Map<VehicleResponse>(savedVehicle));
    }

    [HttpPut]
    public async Task<ActionResult<VehicleResponse>> UpdateVehicle(VehicleResponse vehicleResponse)
    {
        await _vehicleRepository.SaveAsync(_mapper.Map<Vehicle>(vehicleResponse));
        var vehicle = _vehicleRepository.GetAsync(vehicleResponse.VehicleId);

        return vehicle == null ? NotFound() : Ok(_mapper.Map<VehicleResponse>(vehicle));
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteVehicle(VehicleResponse vehicleResponse)
    { 
        await _vehicleRepository.DeleteAsync(vehicleResponse.VehicleId);
        return NoContent();
    }

}
