using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
}
