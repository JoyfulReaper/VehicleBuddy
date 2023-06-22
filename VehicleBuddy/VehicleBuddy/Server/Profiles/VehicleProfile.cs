using AutoMapper;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Shared.Contracts.Vehicle;

namespace VehicleBuddy.Server.Profiles;

public class VehicleProfile : Profile
{
    public VehicleProfile()
    {
        CreateMap<Vehicle, VehicleResponse>()
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.Make))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
            .ForMember(dest => dest.Package, opt => opt.MapFrom(src => src.Package));
        CreateMap<CreateVehicleRequest, Vehicle>();
        CreateMap<UpdateVehicleRequest, Vehicle>();
        CreateMap<Vehicle, UpdateVehicleRequest>();

    }
}