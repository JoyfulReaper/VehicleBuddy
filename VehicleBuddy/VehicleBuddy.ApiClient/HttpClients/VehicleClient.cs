using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using VehicleBuddy.ApiClient.Common;
using VehicleBuddy.ApiClient.Common.Options;
using VehicleBuddy.Shared.Contracts.Vehicle;

namespace VehicleBuddy.ApiClient.HttpClients;

public class VehicleClient : IVehicleClient
{
    private readonly HttpClient _client;
    private readonly IOptions<VehicleBuddyClientOptions> _options;

    public VehicleClient(HttpClient client, IOptions<VehicleBuddyClientOptions> options)
    {
        _client = client;
        _options = options;

        ApiClientConfigurationHelper.ConfigureHttpClient(_client, _options.Value);
    }

    public async Task<VehicleResponse> CreateAsync(CreateVehicleRequest vehicleRequest, CancellationToken cancellationToken = default)
    {
        using var response = await _client.PostAsJsonAsync(_client.BaseAddress + "Vehicle/", vehicleRequest, cancellationToken);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<VehicleResponse>();
        return result ?? throw new Exception("Response deserialized to NULL!");
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        using var response = await _client.DeleteAsync(_client.BaseAddress + $"Vehicle/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    public async Task<List<VehicleResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync<List<VehicleResponse>>(_client.BaseAddress + "/Vehicle", cancellationToken);
        return response ?? new List<VehicleResponse>(); 
    }

    public async Task<VehicleResponse?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync<VehicleResponse>(_client.BaseAddress + $"Vehicle/{id}", cancellationToken);
        return response ?? throw new Exception("Response deserialized to NULL!");

    }

    public async Task<VehicleResponse?> GetByVin(string vin, CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync<VehicleResponse>(_client.BaseAddress + $"Vehicle/Vin/{vin}", cancellationToken);
        return response ?? throw new Exception("Response deserialized to NULL!");
    }

    public async Task<VehicleResponse> UpdateAsync(UpdateVehicleRequest vehicleRequest, CancellationToken cancellationToken = default)
    {
        using var response = await _client.PutAsJsonAsync(_client.BaseAddress + "/Vehicle", vehicleRequest);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<VehicleResponse>() ?? throw new Exception("Response deserialized to NULL!");
    }
}
 