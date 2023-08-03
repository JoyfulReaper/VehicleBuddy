using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using VehicleBuddy.ApiClient.Common;
using VehicleBuddy.ApiClient.Common.Options;
using VehicleBuddy.Shared.Contracts.Fuel;

namespace VehicleBuddy.ApiClient.HttpClients;

public class FuelTypeClient : IFuelTypeClient
{
    private readonly HttpClient _client;
    private readonly VehicleBuddyClientOptions _options;

    public FuelTypeClient(HttpClient client, IOptions<VehicleBuddyClientOptions> options)
    {
        _client = client;
        _options = options.Value;

        ApiClientConfigurationHelper.ConfigureHttpClient(_client, _options);
    }

    public async Task<FuelTypeResponse> CreateAsync(CreateFuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default)
    {
        using var response = await _client.PostAsJsonAsync(_client.BaseAddress + "FuelType/", fuelTypeRequest, cancellationToken);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<FuelTypeResponse>();
        return result;
    }

    public async Task<List<FuelTypeResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync<List<FuelTypeResponse>>(_client.BaseAddress + "FuelType/", cancellationToken);
        return response ?? new List<FuelTypeResponse>();
    }

    public async Task<FuelTypeResponse?> GetAsync(int id, CancellationToken cancellationToken = default)
    {
        var response = await _client.GetFromJsonAsync<FuelTypeResponse>(_client.BaseAddress + $"FuelType/{id}", cancellationToken);
        return response;
    }

    public async Task<FuelTypeResponse> UpdateAsync(UpdateFuelTypeRequest fuelTypeRequest, CancellationToken cancellationToken = default)
    {
        using var response = await _client.PutAsJsonAsync(_client.BaseAddress + "FuelType/", fuelTypeRequest, cancellationToken);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<FuelTypeResponse>();
        return result;
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        using var response = await _client.DeleteAsync(_client.BaseAddress + $"FuelType/{id}", cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
