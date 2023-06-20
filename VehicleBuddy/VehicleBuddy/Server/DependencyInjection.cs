using VehicleBuddy.Server.Data.Interfaces;
using VehicleBuddy.Server.Data;
using VehicleBuddy.Server.Repositories.Interfaces;
using VehicleBuddy.Server.Repositories;

namespace VehicleBuddy.Server;

public static class DependencyInjection
{
    public static IServiceCollection AddVehicleBuddy(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDbConnectionFactory, SqlConnectionFactory>();
        services.AddTransient<IVehicleRepository, VehicleRepository>();
        services.AddTransient<IPackageRepository, PackageRepository>();
        services.AddTransient<IModelRepository, ModelRepository>();
        services.AddTransient<IMakeRepository, MakeRepository>();
        services.AddTransient<IFuelTypeRepository, FuelTypeRepository>();

        return services;
    }
}
