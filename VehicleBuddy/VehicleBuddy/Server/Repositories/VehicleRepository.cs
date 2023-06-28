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
        var result = await connection.QueryAsync<Vehicle, Make, Model, Package, Vehicle>(
           "spVehicle_GetById",
           (v, m, mo, p) =>
           {
               v.Make = m;
               v.Model = mo;
               v.Package = p;
               return v;
           },
           new
           {
               VehicleId = vehicleId
           },
           splitOn: "MakeId,ModelId,PackageId",
           commandType: CommandType.StoredProcedure);

        return result.SingleOrDefault();
    }

    public async Task<Vehicle?> GetByVinAsync(string vin, bool includeSold)
    {
        // TODO: Consider the possibility of duplicated VINs
        // Kyle's Opinion - We should just return a list

        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<Vehicle, Make, Model, Package, Vehicle>(
            "spVehicle_GetByVin",
            (v, m, mo, p) =>
            {
                v.Make = m;
                v.Model = mo;
                v.Package = p;
                return v;
            },
            new
            {
                VIN = vin,
                IncludeSold = includeSold
            },
            splitOn: "MakeId,ModelId,PackageId", 
            commandType: CommandType.StoredProcedure);

        return result.SingleOrDefault();
    }

    public async Task<IList<Vehicle>> GetAllAsync()
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var allVehicles = await connection.QueryAsync<Vehicle, Make, Model, Package, Vehicle>(
            "spVehicle_GetAll",
            (v, m, mo, p) =>
        {
            v.Make = m;
            v.Model = mo;
            v.Package = p;
            return v;
        },
        splitOn: "MakeId,ModelId,PackageId", commandType: CommandType.StoredProcedure);

        return allVehicles.AsList();
    }

    public async Task SaveAsync(Vehicle vehicle)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var id = await connection.QuerySingleAsync<int>("spVehicle_Upsert", 
            new { 
                vehicle.VehicleId,
                vehicle.MakeId,
                vehicle.ModelId,
                vehicle.PackageId,
                vehicle.VIN,
                vehicle.Year,
                vehicle.IsAutomatic,
                vehicle.Color,
                vehicle.DateAcquired,
                vehicle.DateSold,
                vehicle.Mileage
            }, commandType: CommandType.StoredProcedure);
        vehicle.VehicleId = id;

    }

    public async Task SaveImagesAsync(List<Image> images)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        var result = await connection.QueryAsync<Image>("spVehicle_ImageUpload", images, commandType: CommandType.StoredProcedure);
    }

    public async Task DeleteAsync(int vehicleId)
    {
        using IDbConnection connection = _dbConnectionFactory.CreateConnection();
        await connection.ExecuteAsync("spVehicle_Delete", new { vehicleId = vehicleId}, commandType: CommandType.StoredProcedure);

    }

}
