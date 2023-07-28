using VehicleBuddy.Shared.Contracts.Fuel;

namespace VehicleBuddy.ApiClient.HttpClients
{
    public interface IFuelTypeClient
    {
        Task<List<FuelTypeResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<FuelTypeResponse?> GetAsync(int id, CancellationToken cancellationToken = default);

        Task<FuelTypeResponse> UpdateAsync(UpdateFuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default);

        Task<FuelTypeResponse> CreateAsync(CreateFuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default);
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);

    }
}