using AutoMapper;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Shared.Contracts.Package;

namespace VehicleBuddy.Server.Profiles;

public class PackageProfile : Profile
{
    public PackageProfile()
    {
        CreateMap<Package, PackageResponse>()
            .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.FuelType));
    }
}
