using AutoMapper;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Shared.Contracts.Fuel;

namespace VehicleBuddy.Server.Profiles;

public class FuelTypeProfile : Profile
{
    public FuelTypeProfile()
    {
        CreateMap<FuelType, FuelTypeResponse>();
    }
}
