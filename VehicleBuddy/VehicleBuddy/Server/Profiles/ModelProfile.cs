using AutoMapper;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Shared.Contracts.Model;

namespace VehicleBuddy.Server.Profiles;

public class ModelProfile : Profile
{
    public ModelProfile()
    {
        CreateMap<Model, ModelResponse>();
    }
}
