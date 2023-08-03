using VehicleBuddy.Shared.Contracts.Vehicle;

namespace VehicleBuddy.ApiClient.HttpClients;

public interface IVehicleClient
{
    Task<List<VehicleResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<VehicleResponse?> GetAsync(int id, CancellationToken cancellationToken = default);
    Task<VehicleResponse?> GetByVin(string vin, CancellationToken cancellationToken = default);
    Task<VehicleResponse> UpdateAsync(UpdateVehicleRequest vehicleRequest, CancellationToken cancellationToken = default);
    Task<VehicleResponse> CreateAsync(CreateVehicleRequest vehicleRequest, CancellationToken cancellationToken = default);
    Task DeleteAsync(int id, CancellationToken cancellationToken = default);
}
