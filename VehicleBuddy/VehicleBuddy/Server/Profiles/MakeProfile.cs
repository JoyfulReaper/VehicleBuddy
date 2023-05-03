using AutoMapper;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Shared.Contracts.Make;

namespace VehicleBuddy.Server.Profiles;

public class MakeProfile : Profile
{
    public MakeProfile()
    {
        CreateMap<Make, MakeResponse>();
    }
}
