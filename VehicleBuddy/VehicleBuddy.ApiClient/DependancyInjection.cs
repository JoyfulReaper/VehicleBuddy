using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VehicleBuddy.ApiClient.Common.Options;
using VehicleBuddy.ApiClient.HttpClients;

namespace VehicleBuddy.ApiClient;

public static class DependancyInjection
{
    public static IServiceCollection AddVehicleBuddyClient(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<VehicleBuddyClientOptions>(
                configuration.GetSection(nameof(VehicleBuddyClientOptions)));

        services.AddHttpClient<IFuelTypeClient, FuelTypeClient>();
        //services.AddHttpClient<IVehicleClient, VehicleClient>();

        return services;
    }
}
