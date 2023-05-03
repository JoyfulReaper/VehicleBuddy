using System.Data;
using Dapper;
using VehicleBuddy.Server.Data.Interfaces;
using VehicleBuddy.Server.Models;
using VehicleBuddy.Server.Repositories.Interfaces;

namespace VehicleBuddy.Server.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public VehicleRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    /// <summary>
    /// Retreive A vehicle by Id
    /// </summary>
    /// <param name="vehicleId">Id of the vehcile to look up</param>
    /// <returns>The requested vehicle or null if it could not be found</returns>
    public async Task<Vehicle?> GetAsync(int vehicleId)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QuerySingleOrDefaultAsync<Vehicle>("spVehicle_GetById", new { VehicleId = vehicleId }, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<Vehicle?> GetByVinAsync(string vin, bool includeSold)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QuerySingleOrDefaultAsync<Vehicle>("spVehicle_GetByVin", new
        {
            VIN = vin,
            IncludeSold = includeSold
        }, commandType: CommandType.StoredProcedure);
        return result;
    }

    public async Task<IList<Vehicle>> GetAllAsync()
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<Vehicle>("spVehicle_GetAll", commandType: CommandType.StoredProcedure);
        return result.AsList();
    }

    public async Task SaveAsync(Vehicle vehicle)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var id = await connection.QuerySingleAsync<int>("spVehicle_Upsert", vehicle, commandType: CommandType.StoredProcedure);
    }
}
