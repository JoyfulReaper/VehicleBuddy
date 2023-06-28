using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Server.Repositories.Interfaces;
using VehicleBuddy.Shared.Contracts.Fuel;

namespace VehicleBuddy.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]


    public class FuelTypeController : ControllerBase
    {
        private readonly IFuelTypeRepository _fuelTypeRepository;
        private readonly IMapper _mapper;

        public FuelTypeController(IFuelTypeRepository fuelTypeRepository, IMapper mapper)
        {
            _fuelTypeRepository = fuelTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelType>>> GetAll()
        {
            var fuelTypes = await _fuelTypeRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<FuelTypeResponse>>(fuelTypes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuelType>> GetFuelTypeById(int id) 
        {
            var fuelType = await _fuelTypeRepository.GetAsync(id);
            if (fuelType == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FuelTypeResponse>(fuelType));
        }

        [HttpPut]
        public async Task<ActionResult<FuelType>> UpdateFuelType(UpdateFuelTypeRequest updateFuelType) 
        {

            var fuelType = _mapper.Map<FuelType>(updateFuelType);
            await _fuelTypeRepository.SaveAsync(fuelType);
            return Ok(_mapper.Map<FuelTypeResponse>(fuelType));
        }

        [HttpPost]
        public async Task<ActionResult<FuelType>> CreateFuelType(CreateFuelTypeRequest fuelTypeRequest)
        {
            var fuelType = _mapper.Map<FuelType>(fuelTypeRequest);
            await _fuelTypeRepository.SaveAsync(fuelType);

            var output = await _fuelTypeRepository.GetAsync(fuelType.FuelTypeId);

            return Ok(_mapper.Map<FuelTypeResponse>(output));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFuelType(int id)
        { 
            await _fuelTypeRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
