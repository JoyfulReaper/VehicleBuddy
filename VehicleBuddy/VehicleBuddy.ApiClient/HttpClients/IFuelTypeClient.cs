using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleBuddy.Shared.Contracts.Fuel;
using VehicleBuddy.Shared.Contracts.Vehicle;

namespace VehicleBuddy.ApiClient.HttpClients
{
    public interface IFuelTypeClient
    {
        Task<List<FuelTypeResponse>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<FuelTypeResponse?> GetAsync(int id, CancellationToken cancellationToken = default);

        Task<FuelTypeResponse> UpdateAsync(UpdateFuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default);

        Task<FuelTypeResponse> CreateAsync(CreateFuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default);
        Task<FuelTypeResponse> DeleteAsync(int id, CancellationToken cancellationToken = default);

    }
}
